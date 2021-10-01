using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._17_Threads
{
    public static class ThreadsDemo1
    {
        public static void Barman1Attends()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Barman 1 Give beer {i}");
                Thread.Sleep(100);
            }
        }
        public static void Barman2Attends()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Barman 2 Give beer {i}");
                Thread.Sleep(100);
            }
        }
        public static void ThreadsDemo()
        {
            Thread barman1 = new Thread( new ThreadStart(Barman1Attends) );
            Thread barman2 = new Thread(new ThreadStart(Barman2Attends));

            // this 2 works at the same time (parallel)
            barman1.Start();
            barman2.Start();

            // this is secuencial, Barman2Attends does not start until Barman1Attends is done
            //Barman1Attends();
            //Barman2Attends();

        }
    }
}
