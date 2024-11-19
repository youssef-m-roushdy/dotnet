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