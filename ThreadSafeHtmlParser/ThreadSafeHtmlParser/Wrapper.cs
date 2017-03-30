using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser
{
    public class Wrapper
    {
        private readonly object _locker = new object();

        private IWebClient _webClient = null;
        private IHtmlParser _parser = null;

        public Wrapper(IWebClient webClient, IHtmlParser parser)
        {
            _webClient = webClient;
            _parser = parser;
        }

        public IHtmlDocument GetDocument(string urlText)
        {
            lock (_locker)
            {
                Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} loading...");
                string htmlText = _webClient.GetStringAsync(urlText).GetAwaiter().GetResult();
                Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} -> {htmlText}");
            
                Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} parsing...");
                IHtmlDocument result = _parser.Parse(htmlText);
                Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId} -> {result.Content}");

                return result;
            }
        }
    }
}
