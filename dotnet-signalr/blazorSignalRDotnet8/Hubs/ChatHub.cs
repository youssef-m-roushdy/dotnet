using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace blazorSignalRDotnet8.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            //All: all clients connected to chat hub to that signalr server
            //sendAsync: this means to clients we broadcast in essence a message, params(methodName, params)
            //send message mehod when server recieve some messages then server broadcast them back to all users even to the user that has send this meesage
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}