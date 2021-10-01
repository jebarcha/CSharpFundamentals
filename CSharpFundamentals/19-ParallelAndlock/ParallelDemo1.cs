using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals._19_Parallel
{
    public static class ParallelDemo1
    {
        public static void ParallelDemo()
        {
            string fileName = "result.txt";
            var fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            Parallel.For(1, 100, new ParallelOptions { MaxDegreeOfParallelism = 10 },
                (i) => 
                {
                    WriteFile(fileName, i.ToString(), fs);
                });

        }
        public static void WriteFile(string path, string content, FileStream fs)
        {
            Console.WriteLine("some other task here 1");

            lock (fs)
            {
                byte[] bContent = new UTF8Encoding(true).GetBytes(content  + Environment.NewLine);
                fs.Write(bContent, 0, bContent.Length);
                fs.Flush();
            }

            Console.WriteLine("some other task here 2");

            //using (var fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            //{
            //    byte[] bContent = new UTF8Encoding(true).GetBytes(content);
            //    fs.Write(bContent, 0, bContent.Length);
            //      fs.Flush();
            //}
        }
    }
}
