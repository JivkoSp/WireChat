using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models.Dtos;

namespace Wire.Hubs
{
    public class ChatHub : Hub
    {
        public async Task AddToPrivateChat(string userId, GroupDto groupDto)
        {
            await Clients.User(userId).SendAsync("AddToPrivateChat", groupDto);
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendMessageToGroup(string group, MessageDto message)
        {
            message.DateTime = DateTime.Now.ToString("h:mm tt");
            await Clients.Group(group).SendAsync("SendMessageToGroup", message);
        }
    }
}
