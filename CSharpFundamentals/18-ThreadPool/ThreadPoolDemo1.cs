using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._18_ThreadPool
{
    // ThreadPool is a group of threads that are reutilized when is not used.
    public static class ThreadPoolDemo1
    {
        private static string path = @"C:\demos\netcore\CSharpDemos\Files\";
        // when we use ThreadPool, we use delegates
        public static void ThreadPoolDemo()
        {
            //int max, c = 0;
            //ThreadPool.GetMaxThreads(out max, out c);
            //Console.WriteLine(max);

            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(CreateFile, i);
            }

            while (ThreadPool.PendingWorkItemCount > 0);
        }

        public static void CreateFile(object data)
        {
            int i = (int)data;
            string fullPath = path + i + ".txt";
            using (var sw = new StreamWriter(fullPath))
            {
                sw.WriteLine($"Hello, I'm the Thread {Thread.CurrentThread.ManagedThreadId}");
            };
            Console.WriteLine($"Hello, I'm the Thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
