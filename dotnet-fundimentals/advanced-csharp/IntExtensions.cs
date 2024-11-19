using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int num1, int num2)
        {
            return num1 > num2 ? true : false;
        }
    }
}