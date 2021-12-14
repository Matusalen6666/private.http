using System.Collections.Generic;

namespace @private.http
{
    public abstract class Script
{
    public static string Extension { get; private set; } = ".csscript";
    public HttpItem.HttpItemApplication Application { get; set; }
    public HtmlPage Page { get; set; }
    public HttpItem Current { get; set; }

    public abstract void Render(Dictionary<string, string> Args);
}

}