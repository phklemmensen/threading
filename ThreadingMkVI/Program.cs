using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingMkIV;

namespace ThreadingMkVI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Sync thread ****");

            var printer = new Printer();

            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(printer.PrintNumbersSafe);
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }

            threads.ToList().ForEach(t => t.Start());
            Console.ReadLine();

            // a thread safe exchange
            string first = "first";
            string second = "second";
            second = Interlocked.Exchange(ref first, second);


        }
    }
}
