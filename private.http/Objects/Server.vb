Imports System.Text
Imports [private].http.service.http

Public Class Server

    Private WithEvents _Server As HttpServer
    Private _Port As Integer = 8080

    Public ReadOnly Property IsRunning As Boolean
        Get
            Return _Server IsNot Nothing AndAlso _Server.IsListening
        End Get
    End Property

    Public Property BytesReceived As Long
    Public Property BytesSent As Long



    Public Event Update()
    Public Sub Start()
        _Server = New HttpServer(_Port, False, Sub(msg As String)
                                                   Logger.Append(msg)
                                                   RaiseEvent Update()
                                               End Sub)
        _Server.AddHandler(AddressOf Handler)
        _Server.Start()

        RaiseEvent Update()
    End Sub

    Private Function Handler(processor As HttpProcessor, stream As IO.Stream) As HttpServerPipelineResult
        Dim buffer As Byte()
        Dim mime As String = MimeTypes.MimeTypeMap.GetMimeType(".html")

        Dim it As HttpItem = Program.CurrentApplication.FromPath(processor.Path)

        If it Is Nothing Then
            processor.WriteFailure(Net.HttpStatusCode.NotFound, "Resource Not Found", "404: NOT FOUND")
        Else
            buffer = it.GetContent(processor.UrlParameters)
            mime = it.Getmime()

            processor.WriteOKStatusHeader()
            processor.WriteMIMETypeHeader(mime)
            processor.WriteConnectionClosesAfterCommsHeader()
            processor.WriteContentLengthHeader(buffer.Length)
            processor.WriteHeader("Cache-Control", "no-cache")
            processor.WriteHeader("served-by", "private.http")
            processor.WriteEmptyLineToStream()
            processor.WriteDataToStream(buffer)
        End If

        'If TypeOf it Is HttpItem.HttpItemFile Then
        '    Dim extension As String = it.Name.Substring(it.Name.LastIndexOf(".")).ToLower

        '    If extension = ".phttps" Then
        '        buffer = DirectCast(it, HttpItem.HttpItemFile).ExecuteScript(processor.UrlParameters)
        '    Else
        '        If it.Name.Contains(".") Then mime = MimeTypes.MimeTypeMap.GetMimeType(extension)
        '        buffer = it.Data
        '    End If
        'Else
        '    buffer = it.DefaultContent()
        'End If

        Me.BytesReceived += processor.BytesReceived
        Me.BytesSent += processor.BytesSent
        RaiseEvent Update()

        Return HttpServerPipelineResult.HandledExclusively

    End Function

End Class
