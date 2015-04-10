using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        private static bool isDone = false;

        static void Main(string[] args)
        {

            cw("**** Synch Delegate Review ****");
            cw("Main invoked on thread " + Thread.CurrentThread.ManagedThreadId);

            BinaryOperation add = Add;

            // begin async
            add.BeginInvoke(5, 5, AddComplete, "#Hello");

            while (!isDone)
            {
                Thread.Sleep(1000);
                cw("Doing more work in Main");
            }

            cr();
        }

        private static int Add(int x, int y)
        {
            cw("Add() invoked on " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        private static void AddComplete(IAsyncResult asyncResult)
        {
            // end async
            cw("" + asyncResult.AsyncState);
            cw("AddComplete() invoked on " + Thread.CurrentThread.ManagedThreadId);
            cw("Addition complete");
            var add = ((AsyncResult)asyncResult).AsyncDelegate as BinaryOperation;
            if (add == null) throw new Exception("Unexpected delegate type. Bailing out.");

            int answer = add.EndInvoke(asyncResult);
            cw("5 + 5 is " + answer);
            isDone = true;
        }
    }
}
