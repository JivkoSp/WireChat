using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models;

namespace Wire.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task PendingRequestReceived(PendingRequest request)
        {
            await Clients.User(request.ReceiverId).SendAsync("PendingRequestReceived", request);
        }
    }
}
