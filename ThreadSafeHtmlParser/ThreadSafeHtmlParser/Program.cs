using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Implementation;
using ThreadSafeHtmlParser.Interfaces;

namespace ThreadSafeHtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = new[] { "doc-1", "doc-2", "master", "eng" };
            Wrapper w = new Wrapper(new WebClient(), new HtmlParser());

            int taskCount = resources.Length;

            Task<IHtmlDocument>[] tasks = new Task<IHtmlDocument>[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                var res = resources[i];

                Console.WriteLine($"Task ({res}) started");
                tasks[i] = w.GetDocumentAsync(res);
            }

            Task.WaitAll(tasks);

            Console.WriteLine("\nDone!");
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(tasks[i].Result.Content);
            }
            ////////////////////////////////////////////////////

            //Task task = DummyAsync();
            //task.Wait();

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
