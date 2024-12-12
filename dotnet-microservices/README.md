# What Are Microservices

  * Microservices are archictectural approach to build applications from small to large scale
  * With this architectural approach and application is broken down into the smallest components independant of each other
  * Unlike Monolithic architecture where all functionalities are tareted to build into a single project
  * Microservices helps to seperate functionalities to develope in a more modular way and all modules work together to accomplish the specific targeted tasks

## Need Of Microservices

  * It is a major way of designing and optimizing app development towards a cloud-native model
  * This architectural approach to develoaping software gives more modularity and the ability to share similar functionalities across multiple applications
  * To develope quality software the faster development process for change in existing software features easy to tackle any runtime issues after deployment into production

## Advantages Of Microservices

  * Faster Development
  * High scalability 
  * Resilient and Independency
  * Easy of Deployment
  * Accessibility for Deployment

## Principles Of Microservices

  * Modelled Around Business Domain
  * Culture Of Automation
  * Hide Implementation Details
  * Decentralise All The Things
  * Deploy Independently
  * Isolate Failure
  * Highly Observable

## Microservices Archictecture

<b>there are various components in a microservices architecture:</b>

  * `Management`. Maintains the nodes for the services
  * `Identity Provider`: Manages the identity information and provides authentication services within a distributed network
  * `Service Discovery`: Keeps track of services and service addresses and endpoints
  * `API Gateway`: Service as client's entry point. Single point ofcontact from the client which in turn returns responses from underlying microservices
  * `CDN`: A content delivery network to serve static resources
  * `Static Content`: The static resources like pages and web contents

## This Is How Microservices Archictecture Work

<img src="https://ideausher.com/wp-content/uploads/2022/07/Architecture-Of-Microservices-2_result-1024x623.webp" alt=""/>

## Microservices Tools

  * Programing Languages: C#, Python, Java, Node.js, Go, etc
  * `Database`:
    * Relational: SQL Server, MySQL, Postgress SQL, etc
    * Document: Mongodb, etc
    * In memory: Redis, etc
  * `Communication Style`: 
    * HTTP-based web API
    * Messaging via an even bus
    * RESTful APIs, gRPC
  * `Hosting Platform`:
    * Docker and Kubernetes
    * Serverless Functions-as-a-Service
    * Directly on Virtual Machines