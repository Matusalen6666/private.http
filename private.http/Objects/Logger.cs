using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace @private.http
{
    public class Logger
    {
        public static RichTextBox LogControl { get; set; }

        public static void Append(string Content, bool ident = false)
        {
            @private.http.Logger.LogControl.Invoke(new Action(() =>
            {
                @private.http.Logger.LogControl.SelectionLength = 0;
                if (@private.http.Logger.LogControl.Text.Length != 0)
                {
                    @private.http.Logger.LogControl.SelectionStart = @private.http.Logger.LogControl.Text.Length;
                }

                @private.http.Logger.LogControl.SelectionColor = Color.Yellow;
                @private.http.Logger.LogControl.SelectedText = DateAndTime.Now.ToString() + Constants.vbTab;
                @private.http.Logger.LogControl.SelectionLength = 0;
                @private.http.Logger.LogControl.SelectionStart = @private.http.Logger.LogControl.Text.Length;
                @private.http.Logger.LogControl.SelectionColor = Color.WhiteSmoke;
                if (ident)
                    @private.http.Logger.LogControl.AppendText("    ");
                @private.http.Logger.LogControl.AppendText(Content);
                @private.http.Logger.LogControl.AppendText(Constants.vbCrLf);
                @private.http.Logger.LogControl.Select(@private.http.Logger.LogControl.Text.Length - 1, 0);
                @private.http.Logger.LogControl.ScrollToCaret();
            }));
        }
    }

}