using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class Calculation
    {
        public void Calculate(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1/num2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("I will always execute");
                Console.WriteLine(result);
            }   
        }

        public void CalculateAnother()
        {
            
            int num1, num2, result = 0;
            try
            {
                Console.Write("Enter first number: ");
                num1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                num2 = int.Parse(Console.ReadLine());
                result = num1/num2;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("I will always execute");
                Console.WriteLine(result);
            }   
        }
    }
}