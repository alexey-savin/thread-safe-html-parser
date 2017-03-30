using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class WebClient : IWebClient
    {
        public async Task<string> GetStringAsync(string urlText)
        {
            return await Task.Run(() =>
            {
                return $"<{urlText}>";
            });
        }
    }
}
