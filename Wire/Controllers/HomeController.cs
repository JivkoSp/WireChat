using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<AppUser> UserManager;
        private IUnitOfWork UnitOfWork;
        private IHubContext<NotificationHub> HubContext;
        private IMapper Mapper;
        
        private bool ValidPrivatePendingRequest(string senderId, string receiverId, string chatType)
        {
            if(chatType == "Private" && !UnitOfWork.FriendRepo.isFriend(senderId, receiverId) &&
                  !UnitOfWork.PendingRequestRepo.HavePendingRequest(senderId, receiverId))
            {
                return true;
            }

            return false;
        }

        private bool ValidPublicPendingRequest(string senderId, string receiverId, string chatType, int chatId)
        {
            if(chatType == "Public" && !UnitOfWork.UserChatRepo.isMember(receiverId, chatId) &&
                    !UnitOfWork.PendingRequestRepo.HavePendingRequest(senderId, receiverId))
            {
                return true;
            }

            return false;
        }

        public HomeController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IHubContext<NotificationHub> hubContext, IMapper mapper)
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
            Mapper = mapper;
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string userName, string chatType, int chatId)
        {
            try
            {
                var senderId = UserManager.GetUserId(User);
                var receiver = await UserManager.FindByNameAsync(userName);

                if (ValidPrivatePendingRequest(senderId, receiver.Id, chatType)
                  || ValidPublicPendingRequest(senderId, receiver.Id, chatType, chatId))
                {

                    PendingRequest pendingRequest = null;

                    if (chatType == "Public")
                    {
                        if (!UnitOfWork.BannMemberRepo.isUserBannedFromGroup(chatId, receiver.Id))
                        {
                            pendingRequest = new PendingRequest
                            {
                                SenderId = senderId,
                                ReceiverId = receiver.Id,
                                ChatType = chatType,
                                SenderName = User.Identity.Name,
                                GroupPendingRequest = new GroupPendingRequest
                                {
                                    ChatId = chatId
                                }
                            };
                        }
                        else return RedirectToAction("HomePage");
                    }
                    else if(!UnitOfWork.BannMemberRepo.isUserBannedFromContact(receiver.Id, senderId))
                    {
                        pendingRequest = new PendingRequest
                        {
                            SenderId = senderId,
                            ReceiverId = receiver.Id,
                            ChatType = chatType,
                            SenderName = User.Identity.Name
                        };
                    }

                    await UnitOfWork.PendingRequestRepo.AddAsync(pendingRequest);  
                    await UnitOfWork.SaveChangesAsync();
                    
                    //Call notification hub
                    await HubContext.Clients.User(receiver.Id).SendAsync("PendingRequestReceived", 
                        Mapper.Map<PendingRequestDto>(pendingRequest));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("HomePage");
        }

        public IActionResult PendingRequests()
        {
            return View
                (
                    Mapper.Map<IEnumerable<PendingRequestDto>>(
                        UnitOfWork.PendingRequestRepo.GetPendingRequests(UserManager.GetUserId(User)))
                );
        }


        [HttpPost]
        public IActionResult AcceptPendingRequest(PendingRequestDto requestDto)
        {
            return new JsonResult(requestDto);
        }

        [HttpPost]
        public async Task<JsonResult> DeletePendingRequest(PendingRequestDto requestDto)
        {
            UnitOfWork.PendingRequestRepo.Remove(Mapper.Map<PendingRequest>(requestDto));
            await UnitOfWork.SaveChangesAsync();

            string redirectUrl = Url.Action("PendingRequests");

            return new JsonResult(new { redirectUrl });
        }
    }
}
