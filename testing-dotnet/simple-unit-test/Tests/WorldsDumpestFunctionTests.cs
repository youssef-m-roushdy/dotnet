using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Tests
{
    public static class WorldsDumpestFunctionTests
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumpestFunction_ReturnPikachuIfZero_ReturnString()
        {
            try
            {
                //Arrange = go get your variables, whatever you need, your classes, go get function.
                int x = 0;
                WorldsDumpestFunction worldsDumpest = new WorldsDumpestFunction();
                //Act - Excute this function.
                string result = worldsDumpest.ReturnPikachuIfZero(x);

                //Assert - whaterver is returned is it what you want.
                if (result == "Pikachu")
                {
                    Console.WriteLine("PASSED: WorldsDumpestFunction.ReturnPikachuIfZero-ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED: WorldsDumpestFunction.ReturnPikachuIfZero-ReturnsString");
                }
                
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
            }
        }
    }
}