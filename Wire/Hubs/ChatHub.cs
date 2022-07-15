using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;
using Wire.Models.Dtos;

namespace Wire.Hubs
{
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, AppUser> connectedUsers 
            = new ConcurrentDictionary<string, AppUser>();

        private UserManager<AppUser> UserManager;

        public ChatHub(UserManager<AppUser> userManager) 
        {
            UserManager = userManager;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await UserManager.GetUserAsync(Context.User);
            connectedUsers.AddOrUpdate(user.Id, user, (k, v) => user);

            await Clients.All.SendAsync("OnConnectedContactsAsync", connectedUsers);
        }

        public override async Task OnDisconnectedAsync(Exception  exception)
        {
            var user = await UserManager.GetUserAsync(Context.User);
            connectedUsers.AddOrUpdate(user.Id, user, (k, v) => null);

            await Clients.All.SendAsync("OnDisconnectedAsync", connectedUsers);
        }

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

        public async Task CreatePublicGroup(GroupDto groupDto)
        {
            await Clients.Caller.SendAsync("CreatePublicGroup", groupDto);
        }
    }
}
