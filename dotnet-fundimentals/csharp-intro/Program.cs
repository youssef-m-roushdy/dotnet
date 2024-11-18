using System;
using System.Text;
class Program {
    static void Main()
    {
        // Console: Input & Print
        Console.WriteLine("Hello, World!");
        Console.WriteLine("____________________");

        //Variables
        {
        string name = "Youssef Mahmoud";
        int age = 20;
        float balance = 1200.50F;
        double contact = 01235452345;
        char gender = 'A';
        bool isValid = true;

        Console.WriteLine($"Name {name}");
        Console.WriteLine($"Age {age}");
        Console.WriteLine($"Contact {balance}");
        Console.WriteLine($"Gender {gender}");
        Console.WriteLine($"Is Valid Transaction {isValid}");
        }
        Console.WriteLine("____________________");
        // Operators
        {
        float balance = 5000;
        float transaction = 2000;
        Console.WriteLine(balance - transaction);
        }
        Console.WriteLine("____________________");
        //Conditional Statement
        {
        int win = 3;
        int draw = 1;
        int lose = 0;
        int player = 1;
        if(player == win)
        {
            Console.WriteLine($"Player Win: {win} Pionts");
        }
        else if(player == draw)
        {
            Console.WriteLine($"Player Win: {draw} Pionts");
        }
        else
        {
            Console.WriteLine($"Player Win: {lose} Pionts");
        }

        int caseNum = 5;
        switch (caseNum)
        {
            case 1: Console.WriteLine($"process case num: {caseNum}");
            break;
            case 2: Console.WriteLine($"process case num: {caseNum}");
            break;
            case 3: Console.WriteLine($"process case num: {caseNum}");
            break;
            case 4: Console.WriteLine($"process case num: {caseNum}");
            break;
            case 5: Console.WriteLine($"process case num: {caseNum}");
            break;
            default: Console.WriteLine($"process out of case nums");
            break;
        }
        }
        Console.WriteLine("____________________");
        // Loops
        {
        string[] arr = {"Ali", "Youssef", "Ahmed", "Yasser", "Mohamed"};
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }

        foreach (string item in arr)
        {
            Console.WriteLine(item);
        }

        // Jump Statements
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine(i);
            if(i == 5)
                break;
        }

        for (int i = 0; i <= 10; i++)
        {
            if(i % 2 == 1)
                continue;
            Console.WriteLine(i);
            
        }

        int caseNum = 1;
        switch (caseNum)
        {
            case 1:
            Console.WriteLine($"process case num: 1");
            goto case 5;
            case 2: Console.WriteLine($"process case num: 2");
            break;
            case 3: Console.WriteLine($"process case num: 3");
            break;
            case 4: Console.WriteLine($"process case num: 4");
            break;
            case 5: Console.WriteLine($"process case num: 5");
            break;
            default: Console.WriteLine($"process out of case nums");
            break;
        }
        }
        Console.WriteLine("____________________");

        // Arrays & its Types
        {
            
            int[] marks = new int[5] {25, 50, 55, 60, 45};
            // int[] marks = new int[5];
            // marks[0] = 25;
            // marks[1] = 50;
            // marks[2] = 55;
            // marks[3] = 60;
            // marks[4] = 45;

            foreach (int mark in marks)
            {
                Console.Write(mark + "  ");
            }
            Console.WriteLine();

            int[,] multiArray = new int[3, 4]
            {
                {10, 20, 30, 40},
                {50, 60, 70, 80},
                {90, 100, 110, 120}
            };
            for (int i = 0; i < multiArray.GetLength(0); i++)
            {
                for (int j = 0; j < multiArray.GetLength(1); j++)
                {
                    Console.Write(multiArray[i, j] + "  ");
                }
                Console.WriteLine();
            }

            int[][] jaggedArray = new int[2][]
            {
                new int[5] {10, 20, 25, 30, 45},
                new int[2] {70, 95}
            };

            for (int i = 0; i < jaggedArray.Length; i++) // Loop through rows
            {
                for (int j = 0; j < jaggedArray[i].Length; j++) // Loop through columns in each row
                {
                    Console.Write(jaggedArray[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine("____________________");

        // Strings
        {
        string str1 = "Hello World";
        string str2 = "C# Programming";
        Console.WriteLine(str1);
        Console.WriteLine(str1.Length);
        string str3 = string.Concat(str1, " ",str2);
        Console.WriteLine(str3);
        Console.WriteLine(str1.Equals(str2));

        // Immutable string
        string s1 = "C# Programming";
        string s1 = "Java Programming";

        // Mutable string
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("C# Programming");
        stringBuilder.Append("Java Programming");
        }
    }
}