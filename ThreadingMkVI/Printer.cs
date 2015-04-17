using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingMkIV
{
    class Printer
    {
        private Action<string> cwl = Console.WriteLine;
        private Action<string> cw = Console.Write;

        private object _lock = new object();

        /// <summary>
        /// Thread safe version
        /// </summary>
        public void PrintNumbersSafe()
        {
            lock (_lock)
            {
                cwl(string.Format("-> {0} is executing PrintNumbersSafe()", Thread.CurrentThread.Name));

                cw("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    cw(string.Format("{0}, ", i));
                }

                cwl("");
            }
        }
        
        /// <summary>
        /// Not thread safe
        /// </summary>
        public void PrintNumbersUnSafe()
        {
            cwl(string.Format("-> {0} is executing PrintNumbersSafe()", Thread.CurrentThread.Name));

            cw("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Random r = new Random();
                Thread.Sleep(1000 * r.Next(5));
                cw(string.Format("{0}, ", i));
            }

            cwl("");
        }

    }
}
