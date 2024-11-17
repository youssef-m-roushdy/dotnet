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