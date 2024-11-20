using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Declaring a Delegate
delegate int CalculateDelegate(int num);

namespace advanced_csharp
{
    public class DelegateExample
    {
        static int number = 100;
        public static int Addition(int num)
        {
            number += num;
            return number;
        }

        public static int Multiplication(int num)
        {
            number *= num;
            return number;
        }

        public static int GetNumber()
        {
            return number;
        }
    }
}