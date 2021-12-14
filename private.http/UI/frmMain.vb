Public Class frmMain

    Private WithEvents _Server As New Server

    Public Sub New()
        InitializeComponent()
        Logger.LogControl = txtlog
        Me.Text &= $" v.{Application.ProductVersion}"
        RefreshTree(Nothing)
        UpdateStatus()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Logger.Append(Me.Text)
        Logger.Append("Based on @fluffynuts' PeanutButter.SimpleHTTPServer (https://github.com/fluffynuts/PeanutButter)")
    End Sub
    Private Sub UpdateStatus()
        If _Server.IsRunning AndAlso lblStatus.Text <> "running" Then
            lblStatus.Text = "running"
            lblStatus.Image = My.Resources.icons8_green_circle_16
        ElseIf Not _Server.IsRunning AndAlso lblStatus.Text <> "stopped" Then
            lblStatus.Text = "stopped"
            lblStatus.Image = My.Resources.icons8_red_circle_16
        End If

        lblReceived.Text = $"{Formatbytes(_Server.BytesReceived)}"
        lblSent.Text = $"{Formatbytes(_Server.BytesSent)}"

    End Sub

    Private Function Formatbytes(B As Long) As String
        Dim sizes As String() = {"B", "KB", "MB", "GB", "TB"}
        Dim order As Integer = 0

        While B >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            B = B / 1024
        End While

        Return String.Format("{0:0.##} {1}", B, sizes(order))
    End Function

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        _Server.Start()
        UpdateStatus()
    End Sub

    Private Sub TreeFiles_DragOver(sender As Object, e As DragEventArgs) Handles TreeFiles.DragOver
        If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.None
            Return
        End If

        Dim n As TreeNode = TreeFiles.GetNodeAt(TreeFiles.PointToClient(New Point(e.X, e.Y)))
        If n Is Nothing Then n = TreeFiles.Nodes(0)
        TreeFiles.SelectedNode = n

        If TypeOf n.Tag Is HttpItem.HttpItemFile Then
            e.Effect = DragDropEffects.None
        Else
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub TreeFiles_DragDrop(sender As Object, e As DragEventArgs) Handles TreeFiles.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)

        Dim parent As HttpItem = TreeFiles.SelectedNode.Tag

        For Each f As String In files

            If IO.Directory.Exists(f) Then
                LoadFolder(f, parent)
            Else
                LoadFile(f, parent)
            End If
        Next

        RefreshTree(TreeFiles.SelectedNode)

    End Sub

    Private Sub LoadFolder(folder As String, parent As HttpItem)
        Dim strName As String = New IO.DirectoryInfo(folder).Name


        Dim ex As HttpItem = parent.Content.FirstOrDefault(Function(x)
                                                               Return x.Name = strName
                                                           End Function)
        If ex IsNot Nothing Then parent.Content.Remove(ex)

        Dim it As New HttpItem.HttpItemFolder With {.Name = strName, .VirtualPath = $"{parent.VirtualPath}/{strName}"}
        parent.Content.Add(it)

        For Each f As String In IO.Directory.GetDirectories(folder)
            LoadFolder(f, it)
        Next
        For Each f As String In IO.Directory.GetFiles(folder)
            LoadFile(f, it)
        Next

    End Sub

    Private Sub LoadFile(file As String, parent As HttpItem)
        Dim strname As String = New IO.FileInfo(file).Name

        Dim ex As HttpItem = parent.Content.FirstOrDefault(Function(x)
                                                               Return x.Name = strname
                                                           End Function)
        If ex IsNot Nothing Then parent.Content.Remove(ex)


        Dim it As New HttpItem.HttpItemFile With {.Name = strname, .VirtualPath = $"{parent.VirtualPath}/{strname}", .Data = IO.File.ReadAllBytes(file)}
        parent.Content.Add(it)
    End Sub

    Private Sub RefreshTree(ParentNode As TreeNode)
        If ParentNode Is Nothing Then
            TreeFiles.Nodes.Clear()
            Dim tn As TreeNode = TreeFiles.Nodes.Add(Program.CurrentApplication.Name, Program.CurrentApplication.Name, 0, 0)
            tn.Tag = Program.CurrentApplication
            RefreshTree(tn)
            Return
        End If

        ParentNode.Nodes.Clear()
        For Each i As HttpItem In ParentNode.Tag.Content
            If TypeOf i Is HttpItem.HttpItemFolder Then
                Dim tn As TreeNode = ParentNode.Nodes.Add(i.Name, i.Name, 1, 1)
                tn.Tag = i
                RefreshTree(tn)
            Else
                Dim tn As TreeNode = ParentNode.Nodes.Add(i.Name, i.Name, 2, 2)
                tn.Tag = i
            End If

            'Dim tn As TreeNode = ParentNode.Nodes.Add(i.Name)
            'tn.Tag = i

        Next

        ParentNode.Expand()
    End Sub

    Private Sub _Server_Update() Handles _Server.Update
        UpdateStatus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Program.CurrentAppFileName = "" Then
            If SaveDlg.ShowDialog <> DialogResult.OK Then Return
            Program.CurrentAppFileName = SaveDlg.FileName
        End If

        UpdateStatus()
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If OpenDlg.ShowDialog <> DialogResult.OK Then Return

        Program.CurrentAppFileName = OpenDlg.FileName
        Program.CurrentApplication = HttpItem.HttpItemApplication.Load(Program.CurrentAppFileName)

        UpdateStatus()
        RefreshTree(Nothing)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Program.CurrentAppFileName = ""
        Program.CurrentApplication = New HttpItem.HttpItemApplication With {.Name = "root", .VirtualPath = "/"}

        RefreshTree(Nothing)
        UpdateStatus()
    End Sub

    Private Sub txtlog_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles txtlog.LinkClicked
        Process.Start(New ProcessStartInfo(e.LinkText) With {.UseShellExecute = True})
    End Sub
End Class
