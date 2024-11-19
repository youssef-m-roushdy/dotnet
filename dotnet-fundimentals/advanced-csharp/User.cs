using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class User
    {
        private string name;
        private string companyName = "ALPHA";
        private int age;
        private string City{get; set;}
        public string Name { get{return name;} set{name = value;}}
        public string CompanyName { get{return companyName;} }
        public int Age {
            get{return age;}
            set
            {
                if(value < 18)
                    throw new ArithmeticException("Invalid Age");
                age = value;
            }
        }
    }
}