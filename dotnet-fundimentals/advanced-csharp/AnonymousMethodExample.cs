using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public delegate void PrintMessage(string message);
    public class AnonymousMethodExample
    {
        
        public static void InvokeMethod()
        {
            PrintMessage printMessage = delegate(string message)
            {
                Console.WriteLine($"Message: {message}");
            };
            printMessage("Hello World");
        }

    }
}