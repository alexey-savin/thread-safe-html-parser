using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeHtmlParser.Interfaces
{
    public interface IHtmlParser
    {
        IHtmlDocument Parse(string htmlText);
    }
}
