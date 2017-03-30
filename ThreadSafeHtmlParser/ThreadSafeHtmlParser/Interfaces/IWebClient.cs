using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeHtmlParser.Interfaces
{
    public interface IWebClient
    {
        Task<string> GetStringAsync(string urlText);
    }
}
