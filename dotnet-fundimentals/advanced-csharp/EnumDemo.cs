using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    enum WeekDays : byte
    {
        Monday = 5, // 0
        Tuesday = 10, // 1
        Wednesday = 15, // 2
        Thursday = 25, // 3
        Friday, // 4
        Saturday = 30, // 5
        Sunday // 6
    }
    public class EnumDemo
    {
        public void Display()
        {
            int day = (int)WeekDays.Monday;
            Console.WriteLine(WeekDays.Monday + ": " + day);
            day = (int)WeekDays.Tuesday;
            Console.WriteLine(WeekDays.Tuesday + ": " + day);
            day = (int)WeekDays.Friday;
            Console.WriteLine(WeekDays.Friday + ": " + day);
        }
    }
}