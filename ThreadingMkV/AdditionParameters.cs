using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingMkV
{
    class AdditionParameters
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public AdditionParameters(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;
        }
    }
}
