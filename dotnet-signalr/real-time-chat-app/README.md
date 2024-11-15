# Real-time Chat Application

## Hub

Definition: is a central component that enables clients (like browsers or other applications) to communicate with the server in real-time.

## What is a Hub in SignalR?

* A Hub is a class that acts as a high-level pipeline for handling real-time interactions between clients and the server.
* It allows the server to call specific methods on connected clients and vice versa.
* For example, in a chat application, the hub can manage broadcasting messages from one client to all connected clients or specific groups.

## Packages

### NuGet

* Microsoft.AspNet.SignalR

### NPM

* @microsoft/signalr
* react-bootstrap

## ChatHub Class

```
public class ChatHub : Hub
```

1. `ChatHub`:

    * A class derived from Hub, which is a base class in SignalR used to define methods that handle client-server communication.

2. `Hub`:

    * Provides methods for managing connections, groups, and communication between the server and clients.

## JoinChat Method

```
public async Task JoinChat(UserConnction conn)
{
    await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined");
}
```

1. <b>Parameters</b>:

    * `UserConnction conn`:

        * Represents the user trying to join the chat. Likely has properties such as UserName and other connection details.

2. <b>Functionality</b>:

    * Sends a message to all connected clients indicating that a user has joined the chat.

3. <b>Components</b>:

    * Clients: Represents all clients connected to this hub.
    * Clients.All: Targets all connected clients.
    * SendAsync: Sends an asynchronous message to the targeted clients.

    * <b>Message Content</b>:

        * `"ReceiveMessage"`: The name of the client-side method that will handle the message.
        * `"admin"`: The sender of the message (hardcoded here as "admin").
        * `$"{conn.UserName} has joined"`: A dynamic message indicating which user has joined.

## JoinSpecificChatRoom Method

```
public async Task JoinSpecificChatRoom(UserConnction conn)
{
    await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
    await Clients.Group(conn.ChatRoom).SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined {conn.ChatRoom}");
}
```

1. <b>Parameters</b>:

    * `UserConnction conn`: Represents the user attempting to join a specific chat room. Likely includes properties like UserName and ChatRoom.

2. <b>Functionality</b>:

    * Adds a client connection to a specific SignalR group (chat room).
    * Notifies all users in that chat room about the new user.

3. <b>Components</b>:

    * `Groups`: Manages logical groups of connections in SignalR.
        * `AddToGroupAsync`:
            * Associates the client’s connection ID with a specific group (chat room).
            * `Context.ConnectionId`: The unique ID of the connection being established.
        * `Clients.Group`: Targets only the clients in the specified group.
        * `SendAsync`: Sends a message to all users in the chat room.
        * <b>Message Content</b>:
            * `"ReceiveMessage"`: The client-side method to handle the message.
            * `"admin"`: The sender of the message.
            * `$"{conn.UserName} has joined {conn.ChatRoom}"`: A dynamic message indicating which user has joined the chat room.

## Key Concepts

1. <b>SignalR Hub</b>:
    * A SignalR hub is the central point where server methods for client communication are defined.
    * It allows both broadcast messaging (to all clients) and targeted messaging (to specific groups or users).
2. <b>Asynchronous Programming</b>:
    * `async` and `await` are used to ensure non-blocking, real-time messaging operations.
3. <b>Connections and Groups</b>:
    * <b>Connection ID</b>: A unique identifier for each client connection.
    * <b>Groups</b>: Logical groupings of client connections to manage communication within subsets of users, such as chat rooms.
4. <b>Client-Server Communication</b>:
    * The server invokes client-side methods (e.g., `ReceiveMessage`) using the `SendAsync` method.
    * Clients must implement these methods to handle incoming messages.