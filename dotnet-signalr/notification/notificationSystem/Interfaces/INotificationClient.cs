using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notificationSystem.Interfaces
{
    public interface INotificationClient
    {
        Task ReceiveNotification(string message);
    }
}