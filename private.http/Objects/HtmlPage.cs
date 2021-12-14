using System.Text;

namespace @private.http
{
    public class HtmlPage
    {
        public StringBuilder Writer { get; set; } = new StringBuilder();
        public string Source { get; set; }

        public void Begin(string Title)
        {
            WriteHeader(Title);
        }

        public void Close()
        {
            WriteFooter();
            Source = Writer.ToString();
        }

        private void WriteHeader(string Title)
        {
            Writer.AppendLine($"<html><head><title>{Title}</title><link rel=\"icon\" type=\"image/x-icon\" href=\"/@res/app.ico\"></head><body style=\"font-family:verdana; font-size: 9pt;\">");
        }

        private void WriteFooter()
        {
            Writer.AppendLine($"</body></html>");
        }
    }
}