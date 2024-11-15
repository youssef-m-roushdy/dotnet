using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace dotnetChatAppServer.Hubs
{
    public class ChatHub : Hub
    {
        // Hub: allow us access client
        public async Task JoinChat(UserConnction conn)
        {
            //Client: Allows us actually invoke or send messages or receive messages of the clients that are connected to it
            //All: Means that we are targeting everyone
            //SendAsync: Allows us to send messages
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined");
        }

        public async Task JoinSpecificChatRoom(UserConnction conn)
        {
            //Groups: Like creating a section inside our conections or organizing into different areas
            //When establishing connection between user and server a new connection id is being created
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
            await Clients.Group(conn.ChatRoom).SendAsync("ReceiveMessage", "admin", $"{conn.UserName} has joined {conn.ChatRoom}");
        }
    }
}