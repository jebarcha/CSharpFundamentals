using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._16_Task
{
    public static class TaskDemo1
    {
        // Task is a class that allow us to work with asyncronous operations
        // in difference with Threads, Task is more flexible, we can know what is the status of the Task. if returns some data, works with lambda expressions in a practical way.
        // Basically Task is useful to create asyncronous tasks in the same moment.
        public static async Task TaskDemo()
        {
            var task = new Task( () => 
            {
                Thread.Sleep(1000);
                Console.WriteLine("Inner task");
            });
            task.Start();

            var task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Inner task 2");
            });
            task2.Start();
            Console.WriteLine("I do something else here..");
            await task;
            await task2;

            int resultRandom = await RandomAsync();
            Console.WriteLine($"resultRandom: {resultRandom}");

            int resultMult = await MultAsync(5);
            Console.WriteLine($"resultMult: {resultMult}");

            Console.WriteLine("I have done with the task");
            Console.ReadLine();
        }

        public static async Task<int> MultAsync(int num)
        {
            var task = new Task<int>(() => num * num);
            task.Start();
            int result = await task;
            return result;
        }
        public static async Task<int> RandomAsync()
        {
            var task = new Task<int>(() => new Random().Next(100));
            task.Start();
            int result = await task;
            return result;
        }
    }
}
