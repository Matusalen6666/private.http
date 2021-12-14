using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace @private.http
{
    public partial class frmMain
    {
        private Server __Server;

        private Server _Server
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __Server;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__Server != null)
                {
                    __Server.Update -= _Server_Update;
                }

                __Server = value;
                if (__Server != null)
                {
                    __Server.Update += _Server_Update;
                }
            }
        }

        public frmMain()
        {
            _Server = new Server();
            InitializeComponent();
            Logger.LogControl = txtlog;
            Text += $" v.{Application.ProductVersion}";
            RefreshTree(null);
            UpdateStatus();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Logger.Append(Text);
            Logger.Append("Based on @fluffynuts' PeanutButter.SimpleHTTPServer (https://github.com/fluffynuts/PeanutButter)");
        }

        private void UpdateStatus()
        {
            if (_Server.IsRunning && lblStatus.Text != "running")
            {
                lblStatus.Text = "running";
                lblStatus.Image = Properties.Resources.icons8_green_circle_16;
            }
            else if (!_Server.IsRunning && lblStatus.Text != "stopped")
            {
                lblStatus.Text = "stopped";
                lblStatus.Image = Properties.Resources.icons8_red_circle_16;
            }

            lblReceived.Text = $"{this.Formatbytes(_Server.BytesReceived)}";
            lblSent.Text = $"{this.Formatbytes(_Server.BytesSent)}";
        }

        private string Formatbytes(long B)
        {
            var sizes = new[] { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (B >= 1024L && order < sizes.Length - 1)
            {
                order += 1;
                B = (long)Math.Round(B / 1024d);
            }

            return string.Format("{0:0.##} {1}", B, sizes[order]);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _Server.Start();
            UpdateStatus();
        }

        private void TreeFiles_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            TreeFiles.Focus();
            var n = TreeFiles.GetNodeAt(TreeFiles.PointToClient(new Point(e.X, e.Y)));
            if (n is null) n = TreeFiles.Nodes[0];

            TreeFiles.SelectedNode = n;
            if (n.Tag is HttpItem.HttpItemFile)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TreeFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            HttpItem parent = (HttpItem)TreeFiles.SelectedNode.Tag;
            foreach (string f in files)
            {
                if (System.IO.Directory.Exists(f))
                {
                    LoadFolder(f, parent);
                }
                else
                {
                    LoadFile(f, parent);
                }
            }

            RefreshTree(TreeFiles.SelectedNode);
        }

        private void LoadFolder(string folder, HttpItem parent)
        {
            string strName = new System.IO.DirectoryInfo(folder).Name;
            var ex = parent.Content.FirstOrDefault(x => (x.Name ?? "") == (strName ?? ""));
            if (ex is object)
                parent.Content.Remove(ex);
            var it = new HttpItem.HttpItemFolder() { Name = strName, VirtualPath = $"{parent.VirtualPath}/{strName}" };
            parent.Content.Add(it);
            foreach (string f in System.IO.Directory.GetDirectories(folder))
                this.LoadFolder(f, it);
            foreach (string f in System.IO.Directory.GetFiles(folder))
                this.LoadFile(f, it);
        }

        private void LoadFile(string file, HttpItem parent)
        {
            string strname = new System.IO.FileInfo(file).Name;
            var ex = parent.Content.FirstOrDefault(x => (x.Name ?? "") == (strname ?? ""));
            if (ex is object)
                parent.Content.Remove(ex);
            var it = new HttpItem.HttpItemFile() { Name = strname, VirtualPath = $"{parent.VirtualPath}/{strname}", Data = System.IO.File.ReadAllBytes(file) };
            parent.Content.Add(it);
        }

        private void RefreshTree(TreeNode ParentNode)
        {
            if (ParentNode is null)
            {
                TreeFiles.Nodes.Clear();
                var tn = TreeFiles.Nodes.Add(Program.CurrentApplication.Name, Program.CurrentApplication.Name, 0, 0);
                tn.Tag = Program.CurrentApplication;
                this.RefreshTree(tn);
                return;
            }

            ParentNode.Nodes.Clear();
            HttpItem parent = (HttpItem)ParentNode.Tag;
            foreach (HttpItem i in (IEnumerable)parent.Content)
            {
                if (i is HttpItem.HttpItemFolder)
                {
                    var tn = ParentNode.Nodes.Add(i.Name, i.Name, 1, 1);
                    tn.Tag = i;
                    this.RefreshTree(tn);
                }
                else
                {
                    var tn = ParentNode.Nodes.Add(i.Name, i.Name, 2, 2);
                    tn.Tag = i;
                }

                // Dim tn As TreeNode = ParentNode.Nodes.Add(i.Name)
                // tn.Tag = i

            }

            ParentNode.Expand();
        }

        private void _Server_Update()
        {
            UpdateStatus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.CurrentAppFileName))
            {
                if (SaveDlg.ShowDialog() != DialogResult.OK)
                    return;
                Program.CurrentAppFileName = SaveDlg.FileName;
            }

            UpdateStatus();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (OpenDlg.ShowDialog() != DialogResult.OK)
                return;
            Program.CurrentAppFileName = OpenDlg.FileName;
            Program.CurrentApplication = HttpItem.HttpItemApplication.Load(Program.CurrentAppFileName);
            UpdateStatus();
            RefreshTree(null);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Program.CurrentAppFileName = "";
            Program.CurrentApplication = new HttpItem.HttpItemApplication() { Name = "root", VirtualPath = "/" };
            RefreshTree(null);
            UpdateStatus();
        }

        private void txtlog_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.LinkText) { UseShellExecute = true });
        }
    }

}