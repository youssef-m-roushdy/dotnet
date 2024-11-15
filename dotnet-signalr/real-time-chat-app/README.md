# Real-time Chat Application

## Hub

Definition: is a central component that enables clients (like browsers or other applications) to communicate with the server in real-time.

## What is a Hub in SignalR?

* A Hub is a class that acts as a high-level pipeline for handling real-time interactions between clients and the server.
* It allows the server to call specific methods on connected clients and vice versa.
* For example, in a chat application, the hub can manage broadcasting messages from one client to all connected clients or specific groups.

## Packages

* Microsoft.AspNet.SignalR