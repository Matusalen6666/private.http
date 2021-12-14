Imports System.Text

Public Class HtmlPage

    Public Property Writer As New StringBuilder
    Public Property Source As String

    Public Sub Begin(Title As String)
        Me.WriteHeader(Title)
    End Sub

    Public Sub Close()
        WriteFooter()
        Me.Source = Writer.ToString
    End Sub

    Private Sub WriteHeader(Title As String)
        Writer.AppendLine($"<html><head><title>{Title}</title></head><body style=""font-family:verdana; font-size: 9pt;"">")
    End Sub
    Private Sub WriteFooter()
        Writer.AppendLine($"</body></html>")
    End Sub
End Class
