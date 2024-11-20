using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    // Publisher Model
    public class EventExample
    {
        //Delegate Declare
        public delegate void Delegate_OddNumber();
        //Declare Event
        public event Delegate_OddNumber Event_OddNumber;

         public void Addition()
         {
            int num1 = 1;
            int num2 = 2;
            int result = num1 + num2;
            Console.WriteLine(result);
            if(result % 2 != 0 && Event_OddNumber != null)
            {
                // Raised Event
                Event_OddNumber();
            }
         }
    }
}