# CSharp

  * Is a object oriented language developed by microsoft.
  * It bisically runs on .NET Framework
  * C# is abroved as a standard by ECMA and ISO
  * C# is designed for CLI(Command Line Infrastructure)
  * It has a huge community support
  * C# is used to develope web apps, desktop apps, mobile apps, games and much more

# Features

  * Simple
  * Fast Speed
  * Object-Oriented
  * Type Safe
  * Iteroperability
  * Scalable
  * Rich Library
  * Modern Programming Language

# Excution Map

```

                                                Intermediate Code
                                      |--------------------------------------|
    Source Code                       |                                      |                                    Machine Code
    |------------|                    |      Common Intermediate Code        |        Common Language        |---------------------|
    |            |    C# Compiler     |                (CIL) Or,             |          Runtime (CLR)        |                     |
    | C# Program |------------------->|      Intermediate Language Code      |------------------------------>|  Assemblies         |
    |            |                    |                (IL)                  |  (Just-In-Time Compilation)   |  .exe or .dll files |
    |------------|                    |                                      |                               |                     |
                                      |--------------------------------------|                               |---------------------|
```
<b>Steps</b>

1. The program compiled using C# compiler that is known as CSC Compiler
2. At the the stage compiler checks if the code contains an error or not
3. Within the intermediate code gets converted into itermediate programming language which known as CIL, IL Code
4. C# use as part of dotnet framework virtual machine component to manage execution using JIT
5. The process of JIT tells machine to use this native language to understand by machines and execute the code
6. During that process the code gets converted into the .exe(program can be excuted)
or dll(libraries that can be reused across the different platforms) witch is executable piece of code that need to be executed



# Variables

  * Is named storage location in computer memory that holds a value
  * Used to store and manipulation data in a program
  * In C#, all the variables Must be declared before they can be used
  * The basic usnit of storage in program
  * The value stored in variable can be changed during program execution

<b>Variable Types</b>

  * Local Variables
  * Instance or Non-Static Variable
  * Static or Class variable
  * Constant variable
  * ReadOnly variables

<b>Data Types</b>

  * Data types specify the type of data that a valid C# variable can hold
  * C# is strognly-typed language
  * Means we must declare the type of variable that indicates the kind of values it is going to
  store, such as integer, float, decimal, text, etc

<b>C# DataTypes</b>

  * Value DataType
    * Predefined DataTypes(int, bool, float)
    * User defined DataType(Enumeration, Structure)
  * Pionters DataType
  * Refrence DataTypes
    * Predefined DataTypes(objects, strings)
    * User defined DataType(classes interfaces)

# Operators

  * Operators: is the symbol use to perform the operation
  * Operands: Variable or Constant 

<b>Types Of Operations</b>

  * Unary Operator `++, --`
  * Bianry
    * Arithmetic Operator `+, -, *, /, %`
    * Relational Operator `<, <=,>, >=, ==, !=`
    * Logical Operator `&&, ||, !`
    * Bitwise Operator `&, |, <<, >>, -, ^`
    * Assignment Operator `=, +=, -=, *=, %=`
  * Teranry Operator
    * `?:`

# Conditional Statement

<b>Purpose</b>: Conditional statements in programming are used to control the flow of a program based on certain conditions

  * If statement
  * If-Else Statement
  * If-Else-If or Lader Statement
  * Switch

# Loops

A sequence of instruction s that is continually repeated until a certain condition is reached

  * while: `while(condition){code}`
  * do while: `do{code}while(condition)`
  * for: `for(set var, condition, increament)`
  * foreach: `foreach(var object in objects)`

# Jump Statements

<b>Purpose</b>: used to jump from one part of the code to another altering the normal flow of the program

  * `break`: terminate the loop
  * `continue`: skip part of execution within the loop by using condition
  * `goto`: transfer the control to the label statement in the program
  * `return`: terminate the execution of the method
  * `throw`: create an object of any valid exception class with the help of new keword manually using with exception handling

# Arrays

  * A collection of elements with same data type stored in sequence
  * Each element on the array is identified by index, starts with index 0 end with n-1
  * initialize: `int[] arr = new int(5);`

<b>Advantages</b>

  * Code optimization
  * Random access
  * Easy to traverse data
  * Easy to manipulate data
  * Easy to sort data

<b>Types</b>

  * Single-dimentional Array
    * It is the simple type of aray that contains only one row for storing data.
    * It has single set of squere bracket ("[]")
    * Declaring: 
    ``` 
    // declaring array
    int[] age;

    // alocate memory for array
    age = new age[5];
    ```
  * Multi-dimentional Array
    * Array contains more than row to store data on it
    * Known as rectangular array because it has the same length of each row
    * It can be two-dimentional array or three-dimentional or more 
    * contains more than one comma "(,)" within single rectangular brackets ("[,,,]")
    * first dimention for rows and second for columns
    * Declaring: `int[,] s = new int [3,3];`
  * Jagged Array
    * Array of arrays where each sub-array can have different length
    * Useful when need store collection of array with different sizes
    * Declaring:
    ```
    int[][] arr = new int[3][];
    arr[0] = new int[2] {1, 2};
    arr[1] = new int[3] {3, 4, 5};
    arr[2] = new int[4] {6, 7, 8, 9};
    ```
# String

  * Is an object of System.String class that represent sequence of characters
  * Ex: "hello" containing sequence 'h', 'e', 'l', 'l', 'o'
  * Operations on string: concatenation, comparision, getting substring,
  search, trim, replacement etc.
  * string is keyword alias for class System.String class
  * That's why string and String are equivalent
  ```
  string name1 = "Youssef"; // Creating string using string keyword
  String name2 = "Mahmoud"; // Creating string using String class
  ```

<b>Types</b>

  * `Immutable String`
    * Means creating a new memory everytime instead of work on existing memory
    * Whenever we are modifiying a value in existing string we creating a new object witch refers to that mofified string and old one become unrefernced
    * Non-modified
    * System.String class
  * Mutable String
    * Means if we are using the same memory location keeping the stuff of one instance it will not create any further instances
    * hence it will decrease the performance of the application
    * Prefered to String Builder in latest versions
    * Modified
    * System Builder class