<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ToolBar = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnStart = New System.Windows.Forms.ToolStripButton()
        Me.Statusbar = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSpacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblReceived = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtlog = New System.Windows.Forms.RichTextBox()
        Me.HSplitter = New System.Windows.Forms.SplitContainer()
        Me.VSplitter = New System.Windows.Forms.SplitContainer()
        Me.TreeFiles = New System.Windows.Forms.TreeView()
        Me.imlTree = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveDlg = New System.Windows.Forms.SaveFileDialog()
        Me.OpenDlg = New System.Windows.Forms.OpenFileDialog()
        Me.ToolBar.SuspendLayout()
        Me.Statusbar.SuspendLayout()
        CType(Me.HSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HSplitter.Panel1.SuspendLayout()
        Me.HSplitter.Panel2.SuspendLayout()
        Me.HSplitter.SuspendLayout()
        CType(Me.VSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.VSplitter.Panel1.SuspendLayout()
        Me.VSplitter.Panel2.SuspendLayout()
        Me.VSplitter.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar
        '
        Me.ToolBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnOpen, Me.btnSave, Me.ToolStripSeparator1, Me.btnStart})
        Me.ToolBar.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar.Name = "ToolBar"
        Me.ToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolBar.Size = New System.Drawing.Size(802, 25)
        Me.ToolBar.TabIndex = 1
        Me.ToolBar.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNew.Image = Global.[private].http.My.Resources.Resources.icons8_new_file_16
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(23, 22)
        Me.btnNew.Text = "New application"
        '
        'btnOpen
        '
        Me.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOpen.Image = Global.[private].http.My.Resources.Resources.icons8_opened_folder_16
        Me.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(23, 22)
        Me.btnOpen.Text = "Load application"
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = Global.[private].http.My.Resources.Resources.icons8_save_16
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Save application"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnStart
        '
        Me.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStart.Image = Global.[private].http.My.Resources.Resources.icons8_start_16
        Me.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(23, 22)
        Me.btnStart.Text = "Run"
        '
        'Statusbar
        '
        Me.Statusbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Statusbar.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Statusbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblSpacer, Me.lblReceived, Me.lblSent})
        Me.Statusbar.Location = New System.Drawing.Point(0, 456)
        Me.Statusbar.Name = "Statusbar"
        Me.Statusbar.Size = New System.Drawing.Size(802, 22)
        Me.Statusbar.TabIndex = 2
        Me.Statusbar.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblStatus.Image = Global.[private].http.My.Resources.Resources.icons8_green_circle_16
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(65, 17)
        Me.lblStatus.Text = "Status"
        '
        'lblSpacer
        '
        Me.lblSpacer.Name = "lblSpacer"
        Me.lblSpacer.Size = New System.Drawing.Size(592, 17)
        Me.lblSpacer.Spring = True
        '
        'lblReceived
        '
        Me.lblReceived.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblReceived.Image = Global.[private].http.My.Resources.Resources.icons8_sort_down_16
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(79, 17)
        Me.lblReceived.Text = "Received"
        Me.lblReceived.ToolTipText = "Data received"
        '
        'lblSent
        '
        Me.lblSent.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblSent.Image = Global.[private].http.My.Resources.Resources.icons8_sort_up_16
        Me.lblSent.Name = "lblSent"
        Me.lblSent.Size = New System.Drawing.Size(51, 17)
        Me.lblSent.Text = "Sent"
        Me.lblSent.ToolTipText = "Data sent"
        '
        'txtlog
        '
        Me.txtlog.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.txtlog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtlog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtlog.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtlog.Location = New System.Drawing.Point(0, 0)
        Me.txtlog.Name = "txtlog"
        Me.txtlog.ReadOnly = True
        Me.txtlog.Size = New System.Drawing.Size(802, 180)
        Me.txtlog.TabIndex = 4
        Me.txtlog.Text = ""
        Me.txtlog.WordWrap = False
        '
        'HSplitter
        '
        Me.HSplitter.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.HSplitter.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.HSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.HSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.HSplitter.Location = New System.Drawing.Point(0, 25)
        Me.HSplitter.Name = "HSplitter"
        Me.HSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'HSplitter.Panel1
        '
        Me.HSplitter.Panel1.Controls.Add(Me.VSplitter)
        '
        'HSplitter.Panel2
        '
        Me.HSplitter.Panel2.Controls.Add(Me.txtlog)
        Me.HSplitter.Size = New System.Drawing.Size(802, 431)
        Me.HSplitter.SplitterDistance = 247
        Me.HSplitter.TabIndex = 3
        '
        'VSplitter
        '
        Me.VSplitter.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.VSplitter.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.VSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.VSplitter.Location = New System.Drawing.Point(0, 0)
        Me.VSplitter.Name = "VSplitter"
        '
        'VSplitter.Panel1
        '
        Me.VSplitter.Panel1.Controls.Add(Me.TreeFiles)
        '
        'VSplitter.Panel2
        '
        Me.VSplitter.Panel2.Controls.Add(Me.Panel1)
        Me.VSplitter.Size = New System.Drawing.Size(802, 247)
        Me.VSplitter.SplitterDistance = 271
        Me.VSplitter.TabIndex = 0
        '
        'TreeFiles
        '
        Me.TreeFiles.AllowDrop = True
        Me.TreeFiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeFiles.Cursor = System.Windows.Forms.Cursors.Default
        Me.TreeFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeFiles.HideSelection = False
        Me.TreeFiles.ImageIndex = 0
        Me.TreeFiles.ImageList = Me.imlTree
        Me.TreeFiles.Location = New System.Drawing.Point(0, 0)
        Me.TreeFiles.Name = "TreeFiles"
        Me.TreeFiles.SelectedImageIndex = 0
        Me.TreeFiles.Size = New System.Drawing.Size(271, 247)
        Me.TreeFiles.StateImageList = Me.imlTree
        Me.TreeFiles.TabIndex = 4
        '
        'imlTree
        '
        Me.imlTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.imlTree.ImageStream = CType(resources.GetObject("imlTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTree.TransparentColor = System.Drawing.Color.Transparent
        Me.imlTree.Images.SetKeyName(0, "icons8-tree-structure-16.png")
        Me.imlTree.Images.SetKeyName(1, "icons8-folder-16.png")
        Me.imlTree.Images.SetKeyName(2, "icons8-file-16.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(527, 247)
        Me.Panel1.TabIndex = 0
        '
        'SaveDlg
        '
        Me.SaveDlg.Filter = "private.http application files|*.phttp"
        '
        'OpenDlg
        '
        Me.OpenDlg.Filter = "private.http application files|*.phttp"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(802, 478)
        Me.Controls.Add(Me.HSplitter)
        Me.Controls.Add(Me.Statusbar)
        Me.Controls.Add(Me.ToolBar)
        Me.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "private.http"
        Me.ToolBar.ResumeLayout(False)
        Me.ToolBar.PerformLayout()
        Me.Statusbar.ResumeLayout(False)
        Me.Statusbar.PerformLayout()
        Me.HSplitter.Panel1.ResumeLayout(False)
        Me.HSplitter.Panel2.ResumeLayout(False)
        CType(Me.HSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HSplitter.ResumeLayout(False)
        Me.VSplitter.Panel1.ResumeLayout(False)
        Me.VSplitter.Panel2.ResumeLayout(False)
        CType(Me.VSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.VSplitter.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolBar As ToolStrip
    Friend WithEvents Statusbar As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents lblReceived As ToolStripStatusLabel
    Friend WithEvents lblSent As ToolStripStatusLabel
    Friend WithEvents btnStart As ToolStripButton
    Friend WithEvents txtlog As RichTextBox
    Friend WithEvents HSplitter As SplitContainer
    Friend WithEvents VSplitter As SplitContainer
    Friend WithEvents TreeFiles As TreeView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents imlTree As ImageList
    Friend WithEvents lblSpacer As ToolStripStatusLabel
    Friend WithEvents btnNew As ToolStripButton
    Friend WithEvents btnOpen As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SaveDlg As SaveFileDialog
    Friend WithEvents OpenDlg As OpenFileDialog
End Class
