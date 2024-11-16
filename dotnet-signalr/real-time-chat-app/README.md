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
* bootstrap

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
    _shared.connections[Context.ConnectionId] = conn;
    await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
    await Clients.Group(conn.ChatRoom).SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined {conn.ChatRoom}");
}
```

1. <b>Parameters</b>:

    * `UserConnction conn`: Represents the user attempting to join a specific chat room. Likely includes properties like UserName and ChatRoom.

2. <b>Functionality</b>:

    * Stores user connection in a dictionary with connectionId is a key
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

## SendMessage

<p>The method name suggests that it handles sending messages from one user to others in the same chat room.</p>

```
public async Task SendMessage(string msg)
{
    if (_shared.connections.TryGetValue(Context.ConnectionId, out UserConnction conn))
    {
        await Clients.Group(conn.ChatRoom)
            .SendAsync("ReceiveSpecificMessage", conn.UserName, msg);
    }
}
```

<b>Parameters:</b>

* string msg: The content of the message being sent by the user.

<b>Retrieve Connection Details:</b>

* `_shared.connections`:
    * Likely a shared dictionary (or similar collection) that maps connection IDs (`Context.ConnectionId`) to `UserConnction` objects.
    * This collection stores information about all connected users, such as their username and chat room.
* `Context.ConnectionId`:
    * The unique identifier for the current client connection.
* `TryGetValue`:
    * Checks if the dictionary contains the current ConnectionId.
    * If found, assigns the corresponding UserConnction to conn.

<b>Send Message to the Group</b>

* `Clients.Group(conn.ChatRoom)`:
    * Targets all clients in the specific chat room identified by `conn.ChatRoom`.
* SendAsync:
    * Sends a message asynchronously to the targeted group.
* Parameters for `SendAsync`:
    * `"ReceiveSpecificMessage"`: The name of the client-side method that will handle the message.
* `conn.UserName`: The name of the user sending the message.
* `msg`: The content of the message.


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


    