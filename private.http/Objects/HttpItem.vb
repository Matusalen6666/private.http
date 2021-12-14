Imports System.Text
Imports System.Xml.Serialization


<Serializable()>
<XmlInclude(GetType(HttpItem.HttpItemApplication))>
<XmlInclude(GetType(HttpItem.HttpItemFile))>
<XmlInclude(GetType(HttpItem.HttpItemFolder))>
Public MustInherit Class HttpItem
    Private _VirtualPath As String = ""
    Public Property Name As String = ""
    Public Property Content As New List(Of HttpItem)
    Public Property Data As Byte()

    Public Property VirtualPath As String
        Get
            Return _VirtualPath
        End Get
        Set(value As String)
            _VirtualPath = value.Replace("//", "/")
        End Set
    End Property


    Public MustOverride Function GetContent(Params As Dictionary(Of String, String)) As Byte()
    Public Overridable Function Getmime() As String
        Return MimeTypes.MimeTypeMap.GetMimeType(".html")
    End Function

    Public Class HttpItemApplication
        Inherits HttpItem

        Public Overrides Function GetContent(Params As Dictionary(Of String, String)) As Byte()
            Dim defdoc As HttpItem = FolderDefaultDocument(Me)
            If defdoc IsNot Nothing Then Return defdoc.GetContent(Params)
            Return FolderContentView()
        End Function

        Public Sub Save(FileName As String)
            Dim serializer As New XmlSerializer(GetType(HttpItemApplication), New XmlRootAttribute("Application"))
            Using file As System.IO.FileStream = System.IO.File.Open(FileName, IO.FileMode.Create, IO.FileAccess.Write)
                serializer.Serialize(file, Me)
            End Using

            Logger.Append("Application saved.")

        End Sub

        Public Shared Function Load(FileName As String) As HttpItemApplication
            Dim serializer As New XmlSerializer(GetType(HttpItemApplication), New XmlRootAttribute("Application"))
            Using file = System.IO.File.OpenRead(FileName)
                Return DirectCast(serializer.Deserialize(file), HttpItemApplication)
            End Using
            Logger.Append("Application loaded.")
        End Function
    End Class

    Public Class HttpItemFolder
        Inherits HttpItem

        Public Overrides Function GetContent(Params As Dictionary(Of String, String)) As Byte()
            Dim defdoc As HttpItem = FolderDefaultDocument(Me)
            If defdoc IsNot Nothing Then Return defdoc.Data
            Return FolderContentView()
        End Function

    End Class

    Public Class HttpItemFile
        Inherits HttpItem

        Private _script As Script
        Public ReadOnly Property Extension
            Get
                If Me.Name.Contains(".") Then
                    Return Me.Name.Substring(Me.Name.LastIndexOf(".")).ToLower
                Else
                    Return ""
                End If
            End Get
        End Property

        Public Overrides Function GetContent(Params As Dictionary(Of String, String)) As Byte()
            If Extension = Script.Extension Then
                Return ExecuteScript(Params)
            Else
                Return Me.Data
            End If
        End Function

        Public Overrides Function Getmime() As String
            Return MimeTypes.MimeTypeMap.GetMimeType(Me.Extension)
        End Function


        Public Function ExecuteScript(Parameters As Dictionary(Of String, String)) As Byte()
            Try
                Dim ScriptCode As String = Encoding.UTF8.GetString(Data)
                Dim page As New HtmlPage
                page.Begin(Me.VirtualPath)

                'SAMPLE
                'Using @private.http;
                'Public Class Script
                '{
                'Public void Render(HtmlPage page)
                '{
                'page.Writer.AppendLine("<hr>");
                '}
                '}
                If _script Is Nothing Then
                    Logger.Append($"Compiling script for '{Me.VirtualPath}'")
                    _script = CSScriptLib.CSScript.Evaluator.
                    ReferenceAssembliesFromCode(ScriptCode).
                    ReferenceAssemblyOf(Of HtmlPage)().
                    LoadCode(Of Script)(ScriptCode)
                End If
                _script.Application = Program.CurrentApplication
                _script.Page = page
                _script.Current = Me

                Logger.Append($"Executing script '{Me.VirtualPath}'")
                _script.Render(Parameters)

                ' Parameters.Values.ToArray()
                page.Close()

                Return Encoding.UTF8.GetBytes(page.Source)

            Catch ex As Exception
                Logger.Append("Error executing script: " & ex.Message)
                Return Array.Empty(Of Byte)
            End Try
        End Function
    End Class

    Public Function FromPath(path As String) As HttpItem

        If Me.VirtualPath.ToLower = path.ToLower Then
            Return Me
        Else
            For Each i As HttpItem In Me.Content
                Dim r As HttpItem = i.FromPath(path)
                If r IsNot Nothing Then Return r
            Next
        End If

        Return Nothing
    End Function

    Private Function FolderDefaultDocument(Folder As HttpItem) As HttpItem
        Dim defdoc As HttpItem
        defdoc = Me.Content.FirstOrDefault(Function(x)
                                               Return x.Name.ToLower = $"index{Script.Extension}"
                                           End Function)

        If defdoc Is Nothing Then
            defdoc = Me.Content.FirstOrDefault(Function(x)
                                                   Return x.Name.ToLower = "index.html"
                                               End Function)
        End If

        Return defdoc
    End Function
    Private Function FolderContentView() As Byte()
        Dim page As New HtmlPage
        page.Begin(Me.VirtualPath)

        page.Writer.AppendLine($"<div>Contents of <b>{Me.VirtualPath}</b></div>")
        page.Writer.AppendLine($"<hr>")
        For Each it As HttpItem In Me.Content
            page.Writer.AppendLine($"<div><a href={it.VirtualPath}>{it.Name}</a></div>")
        Next
        page.Close()

        Return Encoding.UTF8.GetBytes(page.Source)

    End Function

End Class
