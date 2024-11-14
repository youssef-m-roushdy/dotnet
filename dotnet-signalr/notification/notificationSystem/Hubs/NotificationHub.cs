using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using notificationSystem.Interfaces;

namespace notificationSystem.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId)
                .ReceiveNotification($"Thank you to connecting {Context.User?.Identity?.Name}");
            await base.OnConnectedAsync();
        }
    }
}