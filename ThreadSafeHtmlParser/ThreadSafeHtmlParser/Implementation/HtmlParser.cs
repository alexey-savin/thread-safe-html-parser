using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class HtmlParser : IHtmlParser
    {
        public IHtmlDocument Parse(string htmlText)
        {
            return new HtmlDocument { Content = $"<html>{htmlText}</html>" };
        }
    }
}
