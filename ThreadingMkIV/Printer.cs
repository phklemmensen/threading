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

        public void PrintNumbers()
        {
            cwl(string.Format("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name));

            cw("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                cw(string.Format("{0}, ", i));
                Thread.Sleep(2000);
            }

            cwl("");
        }
    }
}
