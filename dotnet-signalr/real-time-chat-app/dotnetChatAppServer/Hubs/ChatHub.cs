using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetChatAppServer.DataService;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace dotnetChatAppServer.Hubs
{
    public class ChatHub : Hub
    {
        // Hub: allow us access client
        private readonly SharedDb _shared;
        public ChatHub(SharedDb shared)
        {
            _shared = shared;
        }
        public async Task JoinChat(UserConnction conn)
        {
            //Client: Allows us actually invoke or send messages or receive messages of the clients that are connected to it
            //All: Means that we are targeting everyone
            //SendAsync: Allows us to send messages
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined");
        }

        public async Task JoinSpecificChatRoom(UserConnction conn)
        {
            //When establishing connection between user and server a new connection id is being created
            //Store user connection in dict with connection Id is the key
            _shared.connections[Context.ConnectionId] = conn;
            //Groups: Like creating a section inside our conections or organizing into different areas
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
            await Clients.Group(conn.ChatRoom).SendAsync("JoinSpecificChatRoom", "admin", $"{conn.UserName} has joined {conn.ChatRoom}");
        }

        public async Task SendMessage(string msg)
        {
            // Check if the current connection (identified by Context.ConnectionId) exists in the shared connections dictionary
            // If it does, retrieve the corresponding UserConnction object (conn)
            if (_shared.connections.TryGetValue(Context.ConnectionId, out UserConnction conn))
            {
                // Send the message to all clients in the chat room specified in conn.ChatRoom
                // Clients.Group targets only the users connected to this specific group (chat room)
                await Clients.Group(conn.ChatRoom)
                .SendAsync(
                    "ReceiveSpecificMessage", // Name of the client-side method to be called
                    conn.UserName,            // The username of the sender, retrieved from the conn object
                    msg                       // The message content sent by the user
                );
            }
        }
    }
}