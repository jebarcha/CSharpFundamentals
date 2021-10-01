using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamentals._18_ThreadPool
{
    public static class ThreadPoolDemo1
    {
        public static ThreadPoolDemo()
        {
            int max, c = 0;
            ThreadPool.GetMaxThreads(out max, out c);
            Console.WriteLine(max);
        }
    }
}
