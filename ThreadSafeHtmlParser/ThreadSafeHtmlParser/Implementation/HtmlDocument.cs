using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class HtmlDocument : IHtmlDocument
    {
        private string _content;

        public string Content { get => _content; set => _content = value; }
    }
}
