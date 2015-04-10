using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingMkI
{
    public delegate int BinaryOperation(int x, int y);

    class Program
    {
        static Action<string> cw = Console.WriteLine;
        private static Func<string> cr = Console.ReadLine;
 
        static void Main(string[] args)
        {

            cw("**** Synch Delegate Review ****");
            cw("Main invoked on thread " + Thread.CurrentThread.ManagedThreadId);

            BinaryOperation add = Add;

            int answer = add(5, 5);

            cw("Doing more work in Main");
            cw("5 + 5 is " + answer);
            cr();
        }

        private static int Add(int x, int y)
        {
            cw("Add() invoked on " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
