using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadingMkIV
{
    class Program
    {
        private static Action<string> cwl = Console.WriteLine;
        private static Action<string> cw = Console.Write;
        private static Func<string> cr = Console.ReadLine; 

        static void Main(string[] args)
        {
            cw("Choose \"1\" or \"2\". Normal or multithreaded.");

            Thread.CurrentThread.Name = "Primary";

            string path = cr();

            cwl(string.Format("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name));

            var printer = new Printer();
            switch (path)
            {
                case "2":
                    ThreadStart run = printer.PrintNumbers;
                    Thread backgroundThread = new Thread(run);
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                default:
                    printer.PrintNumbers();
                    break;
            }

            MessageBox.Show("Busy waiting!");
        }
    }
}
