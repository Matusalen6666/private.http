using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace @private.http
{
    [DesignerGenerated()]
    public partial class frmMain : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this._btnNew = new System.Windows.Forms.ToolStripButton();
            this._btnOpen = new System.Windows.Forms.ToolStripButton();
            this._btnSave = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnStart = new System.Windows.Forms.ToolStripButton();
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblReceived = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSent = new System.Windows.Forms.ToolStripStatusLabel();
            this._txtlog = new System.Windows.Forms.RichTextBox();
            this.HSplitter = new System.Windows.Forms.SplitContainer();
            this.VSplitter = new System.Windows.Forms.SplitContainer();
            this._TreeFiles = new System.Windows.Forms.TreeView();
            this.imlTree = new System.Windows.Forms.ImageList(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.SaveDlg = new System.Windows.Forms.SaveFileDialog();
            this.OpenDlg = new System.Windows.Forms.OpenFileDialog();
            this.ToolBar.SuspendLayout();
            this.Statusbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSplitter)).BeginInit();
            this.HSplitter.Panel1.SuspendLayout();
            this.HSplitter.Panel2.SuspendLayout();
            this.HSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VSplitter)).BeginInit();
            this.VSplitter.Panel1.SuspendLayout();
            this.VSplitter.Panel2.SuspendLayout();
            this.VSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnNew,
            this._btnOpen,
            this._btnSave,
            this.ToolStripSeparator1,
            this._btnStart});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolBar.Size = new System.Drawing.Size(802, 25);
            this.ToolBar.TabIndex = 1;
            this.ToolBar.Text = "ToolStrip1";
            // 
            // _btnNew
            // 
            this._btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnNew.Image = global::@private.http.Properties.Resources.icons8_new_file_16;
            this._btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnNew.Name = "_btnNew";
            this._btnNew.Size = new System.Drawing.Size(23, 22);
            this._btnNew.Text = "New application";
            this._btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // _btnOpen
            // 
            this._btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnOpen.Image = global::@private.http.Properties.Resources.icons8_opened_folder_16;
            this._btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnOpen.Name = "_btnOpen";
            this._btnOpen.Size = new System.Drawing.Size(23, 22);
            this._btnOpen.Text = "Load application";
            this._btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // _btnSave
            // 
            this._btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnSave.Image = global::@private.http.Properties.Resources.icons8_save_16;
            this._btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(23, 22);
            this._btnSave.Text = "Save application";
            this._btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _btnStart
            // 
            this._btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._btnStart.Image = global::@private.http.Properties.Resources.icons8_start_16;
            this._btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnStart.Name = "_btnStart";
            this._btnStart.Size = new System.Drawing.Size(23, 22);
            this._btnStart.Text = "Run";
            this._btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Statusbar
            // 
            this.Statusbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.Statusbar.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblSpacer,
            this.lblReceived,
            this.lblSent});
            this.Statusbar.Location = new System.Drawing.Point(0, 456);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(802, 22);
            this.Statusbar.TabIndex = 2;
            this.Statusbar.Text = "StatusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblStatus.Image = global::@private.http.Properties.Resources.icons8_red_circle_16;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 17);
            this.lblStatus.Text = "Status";
            // 
            // lblSpacer
            // 
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(561, 17);
            this.lblSpacer.Spring = true;
            // 
            // lblReceived
            // 
            this.lblReceived.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblReceived.Image = global::@private.http.Properties.Resources.icons8_sort_down_16;
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.Size = new System.Drawing.Size(79, 17);
            this.lblReceived.Text = "Received";
            this.lblReceived.ToolTipText = "Data received";
            // 
            // lblSent
            // 
            this.lblSent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSent.Image = global::@private.http.Properties.Resources.icons8_sort_up_16;
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(51, 17);
            this.lblSent.Text = "Sent";
            this.lblSent.ToolTipText = "Data sent";
            // 
            // _txtlog
            // 
            this._txtlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(103)))), ((int)(((byte)(127)))));
            this._txtlog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtlog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._txtlog.Location = new System.Drawing.Point(0, 0);
            this._txtlog.Name = "_txtlog";
            this._txtlog.ReadOnly = true;
            this._txtlog.Size = new System.Drawing.Size(802, 180);
            this._txtlog.TabIndex = 4;
            this._txtlog.Text = "";
            this._txtlog.WordWrap = false;
            this._txtlog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtlog_LinkClicked);
            // 
            // HSplitter
            // 
            this.HSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.HSplitter.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.HSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.HSplitter.Location = new System.Drawing.Point(0, 25);
            this.HSplitter.Name = "HSplitter";
            this.HSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // HSplitter.Panel1
            // 
            this.HSplitter.Panel1.Controls.Add(this.VSplitter);
            // 
            // HSplitter.Panel2
            // 
            this.HSplitter.Panel2.Controls.Add(this._txtlog);
            this.HSplitter.Size = new System.Drawing.Size(802, 431);
            this.HSplitter.SplitterDistance = 247;
            this.HSplitter.TabIndex = 3;
            // 
            // VSplitter
            // 
            this.VSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.VSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.VSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.VSplitter.Location = new System.Drawing.Point(0, 0);
            this.VSplitter.Name = "VSplitter";
            // 
            // VSplitter.Panel1
            // 
            this.VSplitter.Panel1.Controls.Add(this._TreeFiles);
            // 
            // VSplitter.Panel2
            // 
            this.VSplitter.Panel2.Controls.Add(this.Panel1);
            this.VSplitter.Size = new System.Drawing.Size(802, 247);
            this.VSplitter.SplitterDistance = 271;
            this.VSplitter.TabIndex = 0;
            // 
            // _TreeFiles
            // 
            this._TreeFiles.AllowDrop = true;
            this._TreeFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._TreeFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this._TreeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this._TreeFiles.HideSelection = false;
            this._TreeFiles.ImageIndex = 0;
            this._TreeFiles.ImageList = this.imlTree;
            this._TreeFiles.Location = new System.Drawing.Point(0, 0);
            this._TreeFiles.Name = "_TreeFiles";
            this._TreeFiles.SelectedImageIndex = 0;
            this._TreeFiles.Size = new System.Drawing.Size(271, 247);
            this._TreeFiles.StateImageList = this.imlTree;
            this._TreeFiles.TabIndex = 4;
            this._TreeFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeFiles_DragDrop);
            this._TreeFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeFiles_DragOver);
            // 
            // imlTree
            // 
            this.imlTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imlTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTree.ImageStream")));
            this.imlTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTree.Images.SetKeyName(0, "icons8-tree-structure-16.png");
            this.imlTree.Images.SetKeyName(1, "icons8-folder-16.png");
            this.imlTree.Images.SetKeyName(2, "icons8-file-16.png");
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(527, 247);
            this.Panel1.TabIndex = 0;
            // 
            // SaveDlg
            // 
            this.SaveDlg.Filter = "private.http application files|*.phttp";
            // 
            // OpenDlg
            // 
            this.OpenDlg.Filter = "private.http application files|*.phttp";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(802, 478);
            this.Controls.Add(this.HSplitter);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.ToolBar);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "private.http";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.Statusbar.ResumeLayout(false);
            this.Statusbar.PerformLayout();
            this.HSplitter.Panel1.ResumeLayout(false);
            this.HSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSplitter)).EndInit();
            this.HSplitter.ResumeLayout(false);
            this.VSplitter.Panel1.ResumeLayout(false);
            this.VSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VSplitter)).EndInit();
            this.VSplitter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            _btnNew.Name = "btnNew";
            _btnOpen.Name = "btnOpen";
            _btnSave.Name = "btnSave";
            _btnStart.Name = "btnStart";
            _txtlog.Name = "txtlog";
            _TreeFiles.Name = "TreeFiles";


        }

        internal ToolStrip ToolBar;
        internal StatusStrip Statusbar;
        internal ToolStripStatusLabel lblStatus;
        internal ToolStripStatusLabel lblReceived;
        internal ToolStripStatusLabel lblSent;
        private ToolStripButton _btnStart;

        internal ToolStripButton btnStart
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnStart;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnStart != null)
                {
                    _btnStart.Click -= btnStart_Click;
                }

                _btnStart = value;
                if (_btnStart != null)
                {
                    _btnStart.Click += btnStart_Click;
                }
            }
        }

        private RichTextBox _txtlog;

        internal RichTextBox txtlog
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtlog;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtlog != null)
                {
                    _txtlog.LinkClicked -= txtlog_LinkClicked;
                }

                _txtlog = value;
                if (_txtlog != null)
                {
                    _txtlog.LinkClicked += txtlog_LinkClicked;
                }
            }
        }

        internal SplitContainer HSplitter;
        internal SplitContainer VSplitter;
        private TreeView _TreeFiles;

        internal TreeView TreeFiles
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TreeFiles;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TreeFiles != null)
                {
                    _TreeFiles.DragOver -= TreeFiles_DragOver;
                    _TreeFiles.DragDrop -= TreeFiles_DragDrop;
                }

                _TreeFiles = value;
                if (_TreeFiles != null)
                {
                    _TreeFiles.DragOver += TreeFiles_DragOver;
                    _TreeFiles.DragDrop += TreeFiles_DragDrop;
                }
            }
        }

        internal Panel Panel1;
        internal ImageList imlTree;
        internal ToolStripStatusLabel lblSpacer;
        private ToolStripButton _btnNew;

        internal ToolStripButton btnNew
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnNew;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnNew != null)
                {
                    _btnNew.Click -= btnNew_Click;
                }

                _btnNew = value;
                if (_btnNew != null)
                {
                    _btnNew.Click += btnNew_Click;
                }
            }
        }

        private ToolStripButton _btnOpen;

        internal ToolStripButton btnOpen
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnOpen;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnOpen != null)
                {
                    _btnOpen.Click -= btnOpen_Click;
                }

                _btnOpen = value;
                if (_btnOpen != null)
                {
                    _btnOpen.Click += btnOpen_Click;
                }
            }
        }

        private ToolStripButton _btnSave;

        internal ToolStripButton btnSave
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSave;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSave != null)
                {
                    _btnSave.Click -= btnSave_Click;
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                    _btnSave.Click += btnSave_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator1;
        internal SaveFileDialog SaveDlg;
        internal OpenFileDialog OpenDlg;
    }

}