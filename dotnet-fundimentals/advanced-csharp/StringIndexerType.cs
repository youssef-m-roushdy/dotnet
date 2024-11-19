using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class StringIndexerType
    {
        private string[] strArray = new string[10];
        public string this[int index]
        {
            get
            {
                if(index < 0 || index >= strArray.Length)
                    throw new ArgumentOutOfRangeException("Index out of range");
                return strArray[index];
            }
            set
            {
                if(index < 0 || index >= strArray.Length)
                    throw new ArgumentOutOfRangeException("Index out of range");
                strArray[index] = value;
            }
        }
    }
}