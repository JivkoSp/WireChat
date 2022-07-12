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

namespace Wire.Controllers
{
    public class GroupController : Controller
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IHubContext<ChatHub> HubContext { get; set; }
        private UserManager<AppUser> UserManager { get; set; }
        private IMapper Mapper { get; set; }

        public GroupController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext,
            UserManager<AppUser> userManager, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
            UserManager = userManager;
            Mapper = mapper;
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

        [HttpPost]
        public async Task<JsonResult> JoinGroup(PendingRequestDto requestDto)
        {
            try
            {
                var groupPendingReq = UnitOfWork.GroupPendingRequestRepo
                    .GetGroupPendingRequest(requestDto.PendingRequestId);

                UserChat userChat = new UserChat
                {
                    AppUserId = requestDto.ReceiverId,
                    ChatId = groupPendingReq.ChatId,
                    JoinDate = DateTime.Now
                };
     
                await UnitOfWork.UserChatRepo.AddAsync(userChat);
                UnitOfWork.PendingRequestRepo.Remove(Mapper.Map<PendingRequest>(requestDto));
                await UnitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string redirectUrl = Url.Action("PendingRequests", "Home");

            return new JsonResult(new { redirectUrl });
        }
    }
}
