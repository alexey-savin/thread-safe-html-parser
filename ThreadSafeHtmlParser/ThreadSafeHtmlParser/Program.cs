using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Implementation;

namespace ThreadSafeHtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Wrapper w = new Wrapper(new WebClient(), new HtmlParser());

            //int taskCount = 5;
            //Task[] tasks = new Task[taskCount];
            //for (int i = 0; i < taskCount; i++)
            //{
            //    int docno = i;
            //    tasks[i] = Task.Factory.StartNew(() => w.GetDocument($"doc-{docno}"));
            //}

            //Task.WaitAll(tasks);

            //Console.WriteLine("All tasks completed");
            ////////////////////////////////////////////////////

            Task task = DummyAsync();
            task.Wait();

            Console.ReadKey();
        }

        static async Task DummyAsync()
        {
            MyAwaitable awaitable = new MyAwaitable();
            string text = await awaitable;

            Console.WriteLine("I got {0}", text);
        }
    }

    internal class MyAwaitable
    {
        internal MyAwaiter GetAwaiter()
        {
            return new MyAwaiter();
        }
    }

    internal class MyAwaiter : INotifyCompletion
    {
        internal bool IsCompleted { get { return false; } }
        public void OnCompleted(Action continuation)
        {
            Console.WriteLine("This will get called");
            Console.WriteLine("Continuation (ignored) - {0}", continuation);

            // call continuation
            continuation();
        }

        public string GetResult()
        {
            return "Surprise!";
        }
    }
}
