# Advanced CSharp

## Abstract Class

  * A class that cannot be instantiated
  * It serves as a base class for other classes to inherit from
  * Used to define a common set of properties that derived classes should have
  * `abstract` keywork use to create Abstract class:
  ```
  abstract class Test
  {

  }
  ```
  * An Abstract class can have both abstract methods and non-abstract methods Example:
  ```
  abstract class Test
  {
    //Abstract method
    public abstract void display1();

    //Non abstract method
    public void display1()
    {
        Console.WriteLine("Non abstract method");
    }
  }
  ```
### Abstract Mehod
  * A method does not have a body is known as abstract method
  * The `abstract` is used to indicate that a method is abstract
  * An `abstract` method is method is method that is declared but not defined in a base class, and its implementation is left to the derived classes
  * An abstract method must be declared in an abtract class, Example:
  ```
  public abstract class Shape
  {
    public abstract double GetArea();
  }
  ```

## Interface

  * An Interface is similar to abstract class
  * However, unlike abstract classes all methods of an interface are fully abstract
  * Use `interface` keyword to create an interface, Example:
  ```
  interface Rectangle
  {
    void CalculationArea();
  }
  ```
  * Interfaces specify waht a class must do and not how
  * Interfaces can't have private members
  * Interfaces cannot contain fields becasue they represent a particular implementation of data
  * Multiple inheritance is possible with the help of interfaces but not with classes

### Advantages of Interface

  * It used to achieve loose coupling
  * It is used to achieve total abstraction
  * To achieve component-based- programming
  * To achieve multiple inheritance and abstraction
  * Interfaces add a plug and play like architecture into application

## Static Classes & Methods

  * Class cannot be instantiated
  * You cannot create a object of a static class and cannot access static members using an object
  * Apply `static` modifier before the class name and after access modifier to make a class static
  * Syntax:
  ```
  public static class Calculator
  {
    private static int _resultStorage = 0;
    public static string Type = "Arithmetic";
    public static int Sum(int num1, int num2)
    {
        return num1+num2;
    }
    public static int Store(int result)
    {
        _resultStorage = result;
    }
  }
  ```
  * You wiil get error if implement any member non-static
  * If you create a instance from static class you will get error

## Extension Methods

  * Extension methods are additional methods
  * These methods create and add new methods to existing class without creating new child class
  * They are the special type of the static methods that can be called as instance methods
  * We can add extension methods in both predefined classes and user created custom classes
  * Example:
  ```
  int i = 100;

  bool result = i.IsGreaterThan(100);// False 
  ```
  * Is a static method
  * It must have this keyword associate with class name
  * Class name should be the first parameter in the parameter list  