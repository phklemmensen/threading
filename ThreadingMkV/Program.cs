using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingMkV
{
    class Program
    {
        private static Func<int> cr = Console.Read;
        private static Action<string> cwl = Console.WriteLine;
        private static AutoResetEvent _waitHandle = new AutoResetEvent(false);
       
        static void Main(string[] args)
        {
            ParameterizedThreadStart threadStart = Add;
            Thread thread = new Thread(threadStart);
            thread.Start(new AdditionParameters(10, 10));

            _waitHandle.WaitOne();

            cr();
        }

        static void Add(object additionParametersObject)
        {
            var numbers = additionParametersObject as AdditionParameters;
            if (numbers != null)
            {
                cwl("Adding two numbers");
                cwl(string.Format("{0} + {1} = {2}", numbers.Number1, numbers.Number2, numbers.Number1 + numbers.Number2));

            }

            _waitHandle.Set();
        }
    }

}
