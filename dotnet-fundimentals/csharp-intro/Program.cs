using System;

class Program {
    static void Main()
    {
        // Console: Input & Print
        //Console.WriteLine("Hello, World!");

        //Variables
        // string name = "Youssef Mahmoud";
        // int age = 20;
        // float balance = 1200.50F;
        // double contact = 01235452345;
        // char gender = 'A';
        // bool isValid = true;

        // Console.WriteLine($"Name {name}");
        // Console.WriteLine($"Age {age}");
        // Console.WriteLine($"Contact {balance}");
        // Console.WriteLine($"Gender {gender}");
        // Console.WriteLine($"Is Valid Transaction {isValid}");

        // Operators
        // float balance = 5000;
        // float transaction = 2000;
        // Console.WriteLine(balance - transaction);

        // Conditional Statement
        // int win = 3;
        // int draw = 1;
        // int lose = 0;
        // int player = 1;
        // if(player == win)
        // {
        //     Console.WriteLine($"Player Win: {win} Pionts");
        // }
        // else if(player == draw)
        // {
        //     Console.WriteLine($"Player Win: {draw} Pionts");
        // }
        // else
        // {
        //     Console.WriteLine($"Player Win: {lose} Pionts");
        // }

        // int caseNum = 5;
        // switch (caseNum)
        // {
        //     case 1: Console.WriteLine($"process case num: {caseNum}");
        //     break;
        //     case 2: Console.WriteLine($"process case num: {caseNum}");
        //     break;
        //     case 3: Console.WriteLine($"process case num: {caseNum}");
        //     break;
        //     case 4: Console.WriteLine($"process case num: {caseNum}");
        //     break;
        //     case 5: Console.WriteLine($"process case num: {caseNum}");
        //     break;
        //     default: Console.WriteLine($"process out of case nums");
        //     break;
        // }

        // Loops
        string[] arr = {"Ali", "Youssef", "Ahmed", "Yasser", "Mohamed"};
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        
    }
}