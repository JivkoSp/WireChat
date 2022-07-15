using AutoMapper;
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
        private IMapper Mapper;

        public ChatController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext,
            UserManager<AppUser> userManager, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
            UserManager = userManager;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<JsonResult> CreatePrivateChat(PendingRequestDto requestDto)
        {
            try
            {
                Friend senderFriend = new Friend
                {
                    SenderId = requestDto.SenderId,
                    ReceiverId = requestDto.ReceiverId
                };

                Friend receiverFriend = new Friend
                {
                    SenderId = requestDto.ReceiverId,
                    ReceiverId = requestDto.SenderId
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
                    AppUserId = requestDto.SenderId,
                    ChatId = privateChat.ChatId,
                    JoinDate = DateTime.Now
                };

                UserChat newReceiverChat = new UserChat
                {
                    AppUserId = requestDto.ReceiverId,
                    ChatId = privateChat.ChatId,
                    JoinDate = DateTime.Now
                };

                await UnitOfWork.UserChatRepo.AddRangeAsync(new List<UserChat> { newSenderChat, newReceiverChat });

                UnitOfWork.PendingRequestRepo.Remove(Mapper.Map<PendingRequest>(requestDto));

                await UnitOfWork.SaveChangesAsync();

                GroupDto groupDto = new GroupDto
                {
                    ChatId = privateChat.ChatId
                };


                groupDto.GroupName = User.Identity.Name;
                await HubContext.Clients.User(requestDto.SenderId).SendAsync("AddToPrivateChat", requestDto.SenderId, groupDto);
                groupDto.GroupName = requestDto.SenderName;
                await HubContext.Clients.User(requestDto.ReceiverId).SendAsync("AddToPrivateChat", requestDto.ReceiverId, groupDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string redirectUrl = Url.Action("PendingRequests", "Home");

            return new JsonResult(new { redirectUrl });
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
                var user = await UserManager.GetUserAsync(User);

                if(!UnitOfWork.AnonymUserRepo.isUserAnonymous(user.Id))
                {
                    var messageTimeToLive = UnitOfWork.MessageTimeToLiveRepo.FindMessage(user.Id);

                    DateTime time = DateTime.Now.AddDays(1);

                    if(messageTimeToLive != null)
                    {
                        time = DateTime.Now.AddHours(messageTimeToLive.LifeSpan);
                    }

                    Message Message = new Message
                    {
                        Publisher = User.Identity.Name,
                        Content = message,
                        DateTime = DateTime.Now,
                        MessageLifeTime = time,
                        ChatId = chatId
                    };

                    await UnitOfWork.MessageRepo.AddAsync(Message);
                    await UnitOfWork.SaveChangesAsync();
                }       
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
