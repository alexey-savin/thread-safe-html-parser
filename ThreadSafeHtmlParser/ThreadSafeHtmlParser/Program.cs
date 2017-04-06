using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ThreadSafeHtmlParser.Implementation;

namespace ThreadSafeHtmlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = new[] { "doc-1", "doc-2", "master", "eng" };
            Wrapper w = new Wrapper(new WebClient(), new HtmlParser());

            int taskCount = resources.Length;

            Task[] tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                var res = resources[i];

                tasks[i] = Task.Factory.StartNew(async () => 
                {
                    Console.WriteLine($"Task {Task.CurrentId} started ({res})");

                    var idoc = await w.GetDocumentAsync(res);
                    Console.WriteLine(idoc.Content);
                });
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
