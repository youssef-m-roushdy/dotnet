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