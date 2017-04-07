using System.Threading.Tasks;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser.Implementation
{
    public class WebClient : IWebClient
    {
        public async Task<string> GetStringAsync(string urlText)
        {
            await Task.Delay(2000);

            return $"<{urlText}>";
        }
    }
}
