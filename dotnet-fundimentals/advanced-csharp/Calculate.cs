using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public static class Calculate
    {
        static int count = 0;
        static Calculate()
        {
            count = 0;
        }

        public static int Increament()
        {
            count++;
            return count;
        }
        public static int Decreament()
        {
            count--;
            return count;
        }
    }
}