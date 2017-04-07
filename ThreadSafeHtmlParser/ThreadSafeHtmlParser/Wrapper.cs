using System;
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

        private int _downloadingCounter = 0;
        private int _parsingCounter = 0;

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
                ++_downloadingCounter;

                if (_downloadingCounter > 1)
                {
                    Console.WriteLine("More than one downloads!!!");
                }

                Console.WriteLine($"{urlText} Loading...");
                htmlText = await _webClient.GetStringAsync(urlText);
                
                --_downloadingCounter;
            }
            
            lock (_lockParser)
            {
                ++_parsingCounter;

                if (_parsingCounter > 1)
                {
                    Console.WriteLine("More than one parsers!!!");
                }

                Console.WriteLine($"{urlText} Parsing...");
                IHtmlDocument result = _parser.Parse(htmlText);

                --_parsingCounter;
                
                return result;
            }
        }
    }
}
