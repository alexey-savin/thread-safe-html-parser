using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Implementation;

namespace ThreadSafeHtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Wrapper w = new Wrapper(new WebClient(), new HtmlParser());

            int taskCount = 2;
            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => w.GetDocument($"doc-{i}"));
            }

            Task.WaitAll(tasks);

            Console.WriteLine("All tasks completed");

            Console.ReadKey();
        }
    }
}
