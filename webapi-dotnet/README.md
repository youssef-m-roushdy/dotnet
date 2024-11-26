# Basics Of ASP .NET CORE WEB API

## Introduction To Service Oriented Architecture(SOA)

  * Is a design pattern which is designed to build distributed systems that deliver services to other application through the prortocol
  * It defines a way to make software components reusable using the interfaces
  * In SOA applications make use of services available in the network
  * Services are provided to form applications through a network call over the internet
  * It uses common communication standards to speed up the service integrations in applications
  * The services are published in such a way that it easy for developers to assemble their apps using those services
  * It uses a loosely coupled message based communication model to communicate with other applications and other services.

### Benefits Of Using SOA

  * Reusability
  * Greater Adaptablility
  * Manage Complexity
  * Platform Independant
  * Loose Coupling

### Uses Of SOA

  * It could be used to make a reliable service
  * Main use of SOA is to make a reusable service
  * SOA can be used for developing new functions combination
  * It is highly flexible and could be easily configured as per our needs

### SOA Service Connection

  * There are two major roles within Service-oriented Architecture:
    * Service Provider
      * The service provider is the maintainer of the service
      * And the organization that make avaliable one or more services for others to use
      * To advertise the services the the provider can publish them in a registery together with a service contract that specifies the nature of the service how to use it the requirements for the service and the fees charged
    * Service Consumer
      * The service consumer can locate the service metadata in the regisery
      * and develop the required client components to bind and use the service

```
|-------------------|    Service respone     |-------------------|
|                   |<-----------------------|                   |
| Service Provider  |    Service request     | Service Consumer  |
|                   |----------------------->|                   |
|-------------------|                        |-------------------|
```

## Introduction To Representational State Transfer(REST)

  * REST in an architectural style not a protocol
  * It is used for building scalable and efficient web services that can accessed over the internet
  * RESTful Web Services are based on HTTP (Hyper Text Transfer Protocol) protocol
  * RESTful web services exposes a set of resources or objects that can be accessed using standard HTTP methods such as `GET`, `POST`, `PUT`, and `DELETE`

### Advanages Of REST

  * It consumes less bandwidth and resources
  * RESTful web services can be executed in any platform
  * RESTfu web service can use SOAP web service as the implementation
  * RESTful web service permits different data format such as `Plain Text`, `HTML`, `XML`, `JSON`

### RESTful Architecture

  * State and functionality are divided into distributed resources
  * This because every resource has to be accessible via normal HTTP commands
  * Tahat means a user should be able to to issue GET request to get a file POST or PUT request to put a file on the server or DELETE request to delete a file form the server
  * Another principle that works for the RESTful architecture is the `Stateless layered`, `Caching-Support`, and the `Client/Server Architecture`
    * A type of architecture where the web browser acts as the client
    * And the web server as server hosting the application is called a Client/Server architecture
    * The state of application should not maintained by rest
    * The architecture should also be layered meaninig that there can be intermediate servers between the client and the end server
    * It should also be able to implement a well-managed cashing mechanism
    
## Introducing ASP.NET Web API

  * API stands for Appilication Programing Interface
  * ASP.NET Web API is a framework for building Web API HTTP based services on top .NET Framework
  * The most common case of using Web API is building RESTful services
  * these services can then be consumed by a broad range of clients, like
    * Browsers
    * Mobile Application
    * Desltop Application
    * IOT's

## Features of ASP.NET Web API

  * ASP.NET Web API is much similar to ASP.NET MVC
  * Conyains similar features like ASP.NET MVC like:
    * Routing
    * Controllers
    * Action results
    * Filter
    * Model
  * Stand-alone service can be developed using the Web API
  * ASP.NET Web API framework is widely used to develop the RESTful services
