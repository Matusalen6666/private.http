using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace @private.http
{
    [Serializable()]
    [XmlInclude(typeof(HttpItem.HttpItemApplication))]
    [XmlInclude(typeof(HttpItem.HttpItemFile))]
    [XmlInclude(typeof(HttpItem.HttpItemFolder))]
    public abstract class HttpItem
    {
        private string _VirtualPath = "";

        public string Name { get; set; } = "";
        public List<HttpItem> Content { get; set; } = new List<HttpItem>();
        public byte[] Data { get; set; }

        public string VirtualPath
        {
            get
            {
                return _VirtualPath;
            }
            set
            {
                _VirtualPath = value.Replace("//", "/");
            }
        }

        public String CacheControl { get; set; } = "no-cache";


        public abstract String GetIcon();

        public abstract byte[] GetContent(Dictionary<string, string> Params);

        public virtual string GetMime()
        {
            return MimeTypes.MimeTypeMap.GetMimeType(".html");
        }

        public class HttpItemApplication : HttpItem
        {
            public override byte[] GetContent(Dictionary<string, string> Params)
            {
                var defdoc = this.FolderDefaultDocument(this);
                if (defdoc is object)
                    return defdoc.GetContent(Params);
                return this.FolderContentView();
            }

            public void Save(string FileName)
            {
                var serializer = new XmlSerializer(typeof(HttpItemApplication), new XmlRootAttribute("Application"));
                using (var file = System.IO.File.Open(FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    serializer.Serialize(file, this);
                }

                Logger.Append("Application saved.");
            }

            public static HttpItem.HttpItemApplication Load(string FileName)
            {
                var serializer = new XmlSerializer(typeof(HttpItem.HttpItemApplication), new XmlRootAttribute("Application"));
                using (var file = System.IO.File.OpenRead(FileName))
                {
                    Logger.Append("Application loaded.");
                    return (HttpItem.HttpItemApplication)serializer.Deserialize(file);
                }


            }

            public override String GetIcon()
            {
                return "Folder.svg";
            }
        }

        public class HttpItemFolder : HttpItem
        {
            public override byte[] GetContent(Dictionary<string, string> Params)
            {
                var defdoc = this.FolderDefaultDocument(this);
                if (defdoc is object)
                    return defdoc.Data;
                return this.FolderContentView();
            }

            public override string GetIcon()
            {
                return "Folder.svg";
            }
        }

        public class HttpItemFile : HttpItem
        {
            private Script _script;

            public String Extension
            {
                get
                {
                    if (this.Name.Contains("."))
                    {
                        return this.Name.Substring(this.Name.LastIndexOf(".")).ToLower();
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            public override byte[] GetContent(Dictionary<string, string> Params)
            {
                if (Extension == Script.Extension)
                {
                    return ExecuteScript(Params);
                }
                else
                {
                    return this.Data;
                }
            }

            public override string GetMime()
            {
                return MimeTypes.MimeTypeMap.GetMimeType(Extension);
            }

            public byte[] ExecuteScript(Dictionary<string, string> Parameters)
            {
                try
                {
                    string scriptCode = Encoding.UTF8.GetString(this.Data);
                    var page = new HtmlPage();
                    page.Begin(this.VirtualPath);

                    if (_script is null)
                    {
                        Logger.Append($"Compiling script for '{this.VirtualPath}'");
                        _script = CSScriptLib.CSScript.Evaluator.
                            ReferenceAssembliesFromCode(scriptCode).
                            ReferenceAssemblyOf<HtmlPage>().
                            LoadCode<Script>(scriptCode);
                    }

                    _script.Application = Program.CurrentApplication;
                    _script.Page = page;
                    _script.Current = this;
                    Logger.Append($"Executing script '{this.VirtualPath}'");
                    _script.Render(Parameters);

                    page.Close();
                    return Encoding.UTF8.GetBytes(page.Source);
                }
                catch (Exception ex)
                {
                    Logger.Append("Error executing script: " + ex.Message);
                    return Array.Empty<byte>();
                }
            }

            public override string GetIcon()
            {
                if (this.Extension != "")
                {
                    String f = $"Files/{Extension.Replace(".", "")}.svg";
                    String path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), $"res\\{f.Replace("/","\\")}");

                    if (!System.IO.File.Exists(path)) 
                        f = "Files/blank.svg";
                    
                    return f;
                }
                else {
                    return "Files/blank.svg";
                }
                
            }
        }

        public HttpItem FromPath(string path)
        {
            if ((VirtualPath.ToLower() ?? "") == (path.ToLower() ?? ""))
            {
                return this;
            }
            else
            {
                foreach (HttpItem i in Content)
                {
                    var r = i.FromPath(path);
                    if (r is object)
                        return r;
                }
            }

            return null;
        }

        private HttpItem FolderDefaultDocument(HttpItem Folder)
        {
            HttpItem defdoc;
            defdoc = Content.FirstOrDefault(x => (x.Name.ToLower() ?? "") == ($"index{Script.Extension}" ?? ""));
            if (defdoc is null)
            {
                defdoc = Content.FirstOrDefault(x => x.Name.ToLower() == "index.html");
            }

            return defdoc;
        }

        private byte[] FolderContentView()
        {
            var page = new HtmlPage();
            page.Begin(VirtualPath);

            page.Writer.AppendLine($"<div>Contents of <b>{VirtualPath}</b></div>");
            page.Writer.AppendLine($"<hr>");
            foreach (HttpItem it in Content)
            {                
                page.Writer.AppendLine($"<div style=\"height: 24px;\"><img style=\"vertical-align: middle; margin-right:5px;\" height=\"16\" src=\"/@res/{it.GetIcon()}\"><a style=\"vertical-align: middle;\" href=\"{it.VirtualPath}\">{it.Name}</a></div>");
            }
            page.Close();
            return Encoding.UTF8.GetBytes(page.Source);
        }
    }
}