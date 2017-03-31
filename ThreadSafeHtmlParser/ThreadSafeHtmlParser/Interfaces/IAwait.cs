using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSafeHtmlParser.Interfaces
{
    // Undestanding 'await' keyword
    // These don't really exist...
    public interface IAwaitable<T>
    {
        IAwater<T> GetAwaiter();
    }

    public interface IAwater<T>
    {
        bool IsCompleted { get; }
        void OnCompleted(Action continuation);
        T GetResult();
    }
}
