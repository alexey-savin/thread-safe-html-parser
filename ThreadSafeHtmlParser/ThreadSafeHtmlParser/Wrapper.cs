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
        private readonly object _lockParser = new object();
        private readonly AsyncLock _asyncLocker = new AsyncLock();

        private IWebClient _webClient = null;
        private IHtmlParser _parser = null;

        public Wrapper(IWebClient webClient, IHtmlParser parser)
        {
            _webClient = webClient;
            _parser = parser;
        }

        public async Task<IHtmlDocument> GetDocumentAsync(string urlText)
        {
            string htmlText = "";

            using (await _asyncLocker.LockAsync())
            {
                Console.WriteLine($"{urlText} Loading...");
                htmlText = await _webClient.GetStringAsync(urlText);
                Console.WriteLine($"{urlText} done loading");
            }
            
            lock (_lockParser)
            {
                Console.WriteLine($"{urlText} Parsing...");
                IHtmlDocument result = _parser.Parse(htmlText);
                Console.WriteLine($"{urlText} done parsing");

                return result;
            }
        }
    }
}
