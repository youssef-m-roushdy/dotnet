# API Gateway
<b>
API gateway is a vital component in microservices architecture as it solves as an entry point for all the clients to request to the microservices.
</b>

## Ocelot
<b>
It is an open source API gateway that is designed for.NET code. It provides various features such as routing, load balancing, authentication, and much more.
</b>

### Ocelot Tool will help you
  * Routing
  * Load balancing
  * Authentication
  * How to configure
  * Load balancing

## API Gatewat Introduction

  * The API `Gateway` is a server
  * It is a single entry point into a system
  * API Gatewat encapsulates the internal system architecture
  * It provides an API that is tailored to each client
  * It also has other resposibilities such as authentication, monitoring, load balancing, caching request shaping and management, and static response handling
  * API `Gateway` is responsible for request routing, composition, and protocol translation
  * All the request requests made by the client go through the API `Gateway` After that the API `Gateway` routes request to the appropriate microservice
  * The API `Gateway` handles the request in one of the two ways
    * It routes or proxied the requests to the appropriate service
    * Fanninig out(spread) a request to multiple services
  * The API `Gateway` can Provide each client with a custom API
  * It also translets between two protocols such as HTTP, WebSockets, and Web Unfriendly protocols that are used internally

### This Is How API Gateway Works
<img src="https://static.javatpoint.com/tutorial/microservices/images/introduction-to-api-gateways.png" alt="" style="background:white;width:800px"/>

### An API Gatewat including

  * Security
  * Caching
  * API composition and processing
  * Managing access quotas
  * API health monitoring
  * Versioninig
  * Routing

### These are the very specific need of the API Gateway
  * it centralized the access to the decentralized microservices manageable and discovery for scalable and distributed services becomes easy
  * Gives the abstraction for microservice language and protocol independence, which is completely lightweight and independent
  * Routing to microservices based on deployment strategies are very applicable
  * Traffic control to prevent overloading of the resources
  * It reduces the number of round trips between clients and the application.

### Features Of API Gateway

  * Simplified the client access
  * Security and authentication 
  * Load balancing
  * Traffic management
  * Protocol translation