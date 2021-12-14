using System.Linq;

namespace @private.http
{
    public class Server
{
    private service.http.HttpServer _Server;
    private int _Port = 8080;

    public bool IsRunning
    {
        get
        {
            return _Server is object && _Server.IsListening;
        }
    }
    public long BytesReceived { get; set; }
    public long BytesSent { get; set; }

    public event UpdateEventHandler Update;

    public delegate void UpdateEventHandler();

    public void Start()
    {
        _Server = new service.http.HttpServer(_Port, false, (msg) =>
        {
            Logger.Append(msg);
            Update?.Invoke();
        });
        _Server.AddHandler(Handler);
        _Server.Start();
        Update?.Invoke();
    }

    private service.http.HttpServerPipelineResult Handler(service.http.HttpProcessor processor, System.IO.Stream stream)
    {
        byte[] buffer;
        string mime = MimeTypes.MimeTypeMap.GetMimeType(".html");
        var it = Program.CurrentApplication.FromPath(processor.Path);
        if (it is null)
        {
            processor.WriteFailure(System.Net.HttpStatusCode.NotFound, "Resource Not Found", "404: NOT FOUND");
        }
        else
        {
            buffer = it.GetContent(processor.UrlParameters);
            mime = it.Getmime();
            processor.WriteOKStatusHeader();
            processor.WriteMIMETypeHeader(mime);
            processor.WriteConnectionClosesAfterCommsHeader();
            processor.WriteContentLengthHeader(buffer.Length);
            processor.WriteHeader("Cache-Control", "no-cache");
            processor.WriteHeader("served-by", "private.http");
            processor.WriteEmptyLineToStream();
            processor.WriteDataToStream(buffer);
        }

        // If TypeOf it Is HttpItem.HttpItemFile Then
        // Dim extension As String = it.Name.Substring(it.Name.LastIndexOf(".")).ToLower

        // If extension = ".phttps" Then
        // buffer = DirectCast(it, HttpItem.HttpItemFile).ExecuteScript(processor.UrlParameters)
        // Else
        // If it.Name.Contains(".") Then mime = MimeTypes.MimeTypeMap.GetMimeType(extension)
        // buffer = it.Data
        // End If
        // Else
        // buffer = it.DefaultContent()
        // End If

        BytesReceived += processor.BytesReceived;
        BytesSent += processor.BytesSent;
        Update?.Invoke();
        return service.http.HttpServerPipelineResult.HandledExclusively;
    }
}

}