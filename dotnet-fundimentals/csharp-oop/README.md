# Object-Oriented-Programming in CSharp

  * CSharp is object-oriented programming laguage that supports the OOP paradigm
  * Object Oriented Concepts provides a clear moduler structure of programs
  * This makes easy to maintain the existing code
  * Codes can be reused without any redundancy
  * The main aim of OOP to bind together the data and the functions that operate on them so that no other part of the code can access this data except function

## Main Object-Oriented Programming Componants

  * Classes
    * Define the structure using methods and properties that resemble the real world entity.
  * Objects
    * Are instances of the class that holds different data in property fields and can interact with othe objects
  * Encapsulation
    * Means hiding of data whatever data members we declared inside the class are by default encapsulated
    
  * Abstraction
    * If you want to access from outside the class definetion you need to abstract them with helo of access modifiers`(public, private, protected, internal)`
  * Inheritance
    * Helps of reusability of data and also reduces time and efforts of programmer by inherite the methods and properties to sub class 
  * Polymorphism
    * Means one interface multiple functions where the one operation is to be done in different entities that we can define a contract to be followed in all classes for all entities the property would remain same the method would reain same but the functionality would be different

### Classes & Objects

#### Class

  * A class is a blueprint or template for creating objects
  * It defines the properties and behavior of an object
  * A class can also have fields, properties and events
  * They collectively define the data and behavior of an object
  * In object creating class gets its own set of data and behavior based on properties and methods defined in the class
  * Syntax
  ```
  AccessSpecifier class NameOfClass
  {
    // Member variables
    // Member functions
  }
  ```
#### Object

  * An object is a dynamically created instance of the class
  * It is created at runtime so it can be called a runtime entity
  * All the members of the class can be accessed using the object
  * Creating a object: `ClassName nameOfObject = new ClassName();`

### Encapsulation $ Abstraction

#### Encapsulation

  * Is defined as the wrapping up of data under single unit
  * It is the mechanism that binds together code and the data it manipulates
  * In different way encapsulation is a protective shield that prevents the data from being accessed by the code outside shield
  * In encapsulation data in class is hidden from other classes so it is known as data-hiding
  * Encapsulation can be achieved by: Declaring all the variables in the class are private

#### Abstraction

  * Data Abstraction is the property by virtue of which only essential details are exhibited to user
  * Abstract can be achieved with either abstract classes or interfaces
  * The abstract keyword is used for classes and methods:
    * Abstract class:
      - It is restricted class that cannot be used to create objects(to access it, it must be inherited from another class)
    * Abstract methods:
      - It can only be used in an abstract class and it does not have body
      - The body is provided by the derived class(inherited from)

#### Access Modifiers

  * Are used to specify accessibility or scope of variables and functions in the C# application
  * We can choose any of these to protect our data
  * Public is not restricted and Private is most restricted

#### Types Of Access Modifiers

  * Public: Members are accessable everywhere in the program
  * Private: Member accessable only within the class
  * Protected: Helps in inheritance when parent class has any member protected the member are accessed within the child class
  * Internal: Has a most implemented and by default all the classes are iternal, iternal means class or any member if it is iternal can be accessed within its own namespace in whatever mentioned in the namespace but not from the outside the namespace
  * protected internal: protected mean iternal and internal within the namespace

### Constructors

  * A special method used to initialize an object of a class
  * It is similar to a method that is invoked when an object of the class is created
  * Constructor
    - has the same name as that of the class
    - does not have any return types
  * Types of Constructor:
    - Default
    - Parametrized
    - Copy
    - Private
    - Static
  * Constructor Oveloading
    - It allows you to define multiple constructors for a class each with a different set of parameters
    - This allows you to create objects of the class with different initial states depending on the arguments passed to the constructor
    - It allows you to make your code more flexible and reusable
