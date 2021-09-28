using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._12_AsyncronousTasks
{
    public static class AsyncDemo1
    {
        public static void AsyncDemo()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(Request1, token);
            tasks[1] = Task.Run(Request2);
            tasks[2] = Task.Run(Request1, token);

            //Console.WriteLine("Waiting here...");

            Task.Delay(500);
            source.Cancel();

            try
            {
                Task.WaitAll(tasks);
            }
            catch {}

            foreach (var t in tasks)
            {
                Console.WriteLine(t.Status);
            }

            //Task task = Task.Run(() => {
            //    Task.Delay(1000);
            //    Console.WriteLine("Hello World");
            //});
            //Task.WaitAll();

            Console.WriteLine("end");
        }
        private static void Request1()
        {
            Task.Delay(2000);
            Console.WriteLine("Service request 1");
        }
        private static void Request2()
        {
            Task.Delay(2000);
            Console.WriteLine("Service request 2");
        }
    }
}
