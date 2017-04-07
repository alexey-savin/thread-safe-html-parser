using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class HtmlDocument : IHtmlDocument
    {
        public string Content { get; set; }
    }
}
