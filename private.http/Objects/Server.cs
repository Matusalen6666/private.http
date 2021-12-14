using System.Linq;
using System;

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

            HttpItem it;
            if (processor.Path.ToLower().StartsWith("/@res"))
                it = GetResourceItem(processor.Path);
            else
                it = Program.CurrentApplication.FromPath(processor.Path);

            if (it is null)
            {
                processor.WriteFailure(System.Net.HttpStatusCode.NotFound, "Resource Not Found", "404: NOT FOUND");
            }
            else
            {
                buffer = it.GetContent(processor.UrlParameters);
                mime = it.GetMime();
                processor.WriteOKStatusHeader();
                processor.WriteMIMETypeHeader(mime);
                processor.WriteContentLengthHeader(buffer.Length);
                processor.WriteHeader("Cache-Control", it.CacheControl);
                processor.WriteHeader("served-by", "private.http");
                processor.WriteEmptyLineToStream();
                processor.WriteDataToStream(buffer);
            }

            BytesReceived += processor.BytesReceived;
            BytesSent += processor.BytesSent;
            Update?.Invoke();
            return service.http.HttpServerPipelineResult.HandledExclusively;
        }

        private HttpItem.HttpItemFile GetResourceItem(string path)
        {

            path = path
                .Replace("/@", "")
                .Replace("/", "\\");
            path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), path);

            if (System.IO.File.Exists(path))
            {
                var it = new HttpItem.HttpItemFile()
                {
                    Name = new System.IO.FileInfo(path).Name,
                    Data = System.IO.File.ReadAllBytes(path),
                    CacheControl = "public, max-age=604800, immutable"
                };
                return it;
            }
            else
                return null;



        }


    }

}