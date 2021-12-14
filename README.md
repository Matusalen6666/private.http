# private.http
Simple private http server with (some) server side scripting.

The server can serve any file type, sending mime header based on file extension.

Example script file (*.csscript)
```C#
using System;
using System.Collections.Generic;
using @private.http;
using System.Text;

public class PageScript : @private.http.Script 
{
    public override void Render(Dictionary<string, string> Parameters)
    {
        Page.Writer.AppendLine($"<div>Contents of <b>{Current.VirtualPath}</b></div>");
        Page.Writer.AppendLine("<hr>");

        foreach(HttpItem it in Current.Content){
            Page.Writer.AppendLine($"<div><a href={it.VirtualPath}>{it.Name}</a></div>");
        }
    }
}
```
