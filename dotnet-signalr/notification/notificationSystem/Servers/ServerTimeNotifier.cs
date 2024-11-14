// ServerTimeNotifier.cs
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using notificationSystem.Hubs;
using notificationSystem.Interfaces;

namespace notificationSystem.Servers
{
    public class ServerTimeNotifier : BackgroundService
    {
        // Time interval for notifications
        private static readonly TimeSpan Period = TimeSpan.FromSeconds(5);
        private readonly ILogger<ServerTimeNotifier> _logger;
        private readonly IHubContext<NotificationHub, INotificationClient> _context;

        public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<NotificationHub, INotificationClient> context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var dateTime = DateTime.Now;
                _logger.LogInformation("Executing {Service} at {Time}", nameof(ServerTimeNotifier), dateTime);

                // Send notification to all connected clients
                await _context.Clients.All.ReceiveNotification($"Server time = {dateTime}");

                await Task.Delay(Period, stoppingToken); // Delay before the next iteration
            }
        }
    }
}
