Public MustInherit Class Script

    Public Shared ReadOnly Property Extension As String = ".csscript"

    Public Property Application As HttpItem.HttpItemApplication
    Public Property Page As HtmlPage
    Public Property Current As HttpItem

    Public MustOverride Sub Render(Args As Dictionary(Of String, String))


End Class
