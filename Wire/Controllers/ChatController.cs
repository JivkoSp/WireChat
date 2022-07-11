using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Hubs;
using Wire.Models;
using Wire.Models.Dtos;
using Wire.Models.ViewModels;

namespace Wire.Controllers
{
    public class ChatController : Controller
    {
        private IUnitOfWork UnitOfWork;
        private IHubContext<ChatHub> HubContext;
        private UserManager<AppUser> UserManager;

        public ChatController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext,
            UserManager<AppUser> userManager)
        {
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
            UserManager = userManager;
        }

        [HttpPost]
        public async Task CreatePrivateChat(string senderId, string receiverId)
        {
            try
            {
                Friend senderFriend = new Friend
                {
                    SenderId = senderId,
                    ReceiverId = receiverId
                };

                Friend receiverFriend = new Friend
                {
                    SenderId = receiverId,
                    ReceiverId = senderId
                };

                await UnitOfWork.FriendRepo.AddRangeAsync(new List<Friend> { senderFriend, receiverFriend });

                Chat privateChat = new Chat
                {
                    ChatTypeId = UnitOfWork.ChatTypeRepo.GetChatTypeId("Private")
                };

                await UnitOfWork.ChatRepo.AddAsync(privateChat);
                await UnitOfWork.SaveChangesAsync();

                UserChat newSenderChat = new UserChat
                {
                    AppUserId = senderId,
                    ChatId = privateChat.ChatId,
                    JoinDate = DateTime.Now
                };

                UserChat newReceiverChat = new UserChat
                {
                    AppUserId = receiverId,
                    ChatId = privateChat.ChatId,
                    JoinDate = DateTime.Now
                };

                await UnitOfWork.UserChatRepo.AddRangeAsync(new List<UserChat> { newSenderChat, newReceiverChat });
                await UnitOfWork.SaveChangesAsync();

                GroupDto groupDto = new GroupDto
                {
                    ChatId = privateChat.ChatId
                };

                await HubContext.Clients.User(senderId).SendAsync("AddToPrivateChat", senderId, groupDto);
                await HubContext.Clients.User(receiverId).SendAsync("AddToPrivateChat", receiverId, groupDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IActionResult ChatRoom(int ChatId, string roomType="Private")
        {
            return View
                (
                    new ChatRoomViewModel
                    {
                        RoomType = roomType,
                        Messages = UnitOfWork.MessageRepo.GetMessages(ChatId)
                    }
                );
        }

        [HttpPost]
        public async Task PostMessage(int chatId, string message)
        {
            try
            {
                Message Message = new Message
                {
                    Publisher = User.Identity.Name,
                    Content = message,
                    DateTime = DateTime.Now,
                    ChatId = chatId
                };

                await UnitOfWork.MessageRepo.AddAsync(Message);
                await UnitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [HttpPost]
        public async Task CreateGroup(string groupName, int groupTypeId)
        {
            try
            {
               string userId = UserManager.GetUserId(User);

               UserChat userChat = new UserChat
                {
                    AppUserId = userId,
                    JoinDate = DateTime.Now,
                    Chat = new Chat
                    {
                        ChatTypeId = UnitOfWork.ChatTypeRepo.GetChatTypeId("Public"),
                        Group = new Group
                        {
                            GroupName = groupName,
                            GroupTypeId = groupTypeId
                        }
                    }
                };

                await UnitOfWork.UserChatRepo.AddAsync(userChat);
                await UnitOfWork.SaveChangesAsync();

                GroupDto groupDto = new GroupDto
                {
                    ChatId = userChat.Chat.ChatId,
                    GroupName = groupName
                };

                await HubContext.Clients.User(userId).SendAsync("CreatePublicGroup", groupDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
