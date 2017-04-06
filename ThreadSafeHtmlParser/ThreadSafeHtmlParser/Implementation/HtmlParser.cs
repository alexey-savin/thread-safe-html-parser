using System.Threading;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class HtmlParser : IHtmlParser
    {
        public IHtmlDocument Parse(string htmlText)
        {
            Thread.Sleep(3000);

            return new HtmlDocument { Content = $"<html>{htmlText}</html>" };
        }
    }
}
