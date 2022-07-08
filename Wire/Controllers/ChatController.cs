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

namespace Wire.Controllers
{
    public class ChatController : Controller
    {
        private IUnitOfWork UnitOfWork;
        private IHubContext<ChatHub> HubContext;

        public ChatController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext)
        {
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
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
                    ChatType = "Private"
                };

                UserChat newReceiverChat = new UserChat
                {
                    AppUserId = receiverId,
                    ChatId = privateChat.ChatId,
                    ChatType = "Private"
                };

                await UnitOfWork.UserChatRepo.AddRangeAsync(new List<UserChat> { newSenderChat, newReceiverChat });
                await UnitOfWork.SaveChangesAsync();

                GroupDto groupDto = new GroupDto
                {
                    GroupId = privateChat.ChatId
                };

                await HubContext.Clients.User(senderId).SendAsync("AddToPrivateChat", senderId, groupDto);
                await HubContext.Clients.User(receiverId).SendAsync("AddToPrivateChat", receiverId, groupDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IActionResult ChatRoom(int ChatId)
        {
            return View(UnitOfWork.MessageRepo.GetMessages(ChatId));
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
    }
}
