using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private IUnitOfWork UnitOfWork;
        private IMapper Mapper;

        public ChatHub(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper) 
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public static ConcurrentDictionary<string, AppUser> GetConnectedUsers()
        {
            return connectedUsers;
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                var user = await UserManager.GetUserAsync(Context.User);
                connectedUsers.AddOrUpdate(user.Id, user, (k, v) => user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            await Clients.All.SendAsync("OnConnectedContactsAsync", connectedUsers);
        }

        public override async Task OnDisconnectedAsync(Exception  exception)
        {
            try
            {
                var user = await UserManager.GetUserAsync(Context.User);
                connectedUsers.AddOrUpdate(user.Id, user, (k, v) => null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        public async Task ActiveChat(ActiveChatDto activeChatDto)
        {
            await Clients.Group(activeChatDto.ChatId.ToString()).SendAsync("ActiveChat", activeChatDto);
        }

        public async Task NonActiveChats()
        {
            var activeChats = UnitOfWork.ActiveChatRepo
                   .GetActiveChats(Context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var oldChats = activeChats.Where(chat => chat.DateTime.CompareTo(DateTime.Now) <= 0);

            if (oldChats.Any())
            {
                foreach(var chat in oldChats)
                {
                    await Clients.Group(chat.ChatId.ToString())
                        .SendAsync("NonActiveChats", Mapper.Map<IEnumerable<ActiveChatDto>>(oldChats));
                }

                UnitOfWork.ActiveChatRepo.RemoveRange(oldChats);
                await UnitOfWork.SaveChangesAsync();
            }         
        }
    }
}
