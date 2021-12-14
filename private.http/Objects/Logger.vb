Public Class Logger
    Public Shared Property LogControl As RichTextBox


    Public Shared Sub Append(Content As String, Optional ByVal ident As Boolean = False)

        LogControl.Invoke(Sub()

                              LogControl.SelectionLength = 0
                              If LogControl.Text.Length <> 0 Then
                                  LogControl.SelectionStart = LogControl.Text.Length
                              End If

                              LogControl.SelectionColor = Color.Yellow
                              LogControl.SelectedText = Now.ToString & vbTab


                              LogControl.SelectionLength = 0
                              LogControl.SelectionStart = LogControl.Text.Length
                              LogControl.SelectionColor = Color.WhiteSmoke

                              If ident Then LogControl.AppendText("    ")
                              LogControl.AppendText(Content)

                              LogControl.AppendText(vbCrLf)

                              LogControl.Select(LogControl.Text.Length - 1, 0)
                              LogControl.ScrollToCaret()
                          End Sub)

    End Sub
End Class
