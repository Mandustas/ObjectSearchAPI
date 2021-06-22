using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ObjectSearchAPI.Services;

namespace ObjectSearchAPI.Hubs
{
    public class NotificationHub : Hub
    {
        public NotificationHub(
            )
        {
        }
        public Task SendMessage(string message)
        {
            return Clients.All.SendAsync("SendMessage", message);
        }

        public Task Notification(string mess)
        {
            return Clients.Others.SendAsync("Notification", mess);
        }
    }
}
