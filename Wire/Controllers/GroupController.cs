using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Hubs;
using Wire.Models;
using Wire.Models.Dtos;
using Wire.Models.ViewModels;

namespace Wire.Controllers
{
    public class GroupController : Controller
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IHubContext<ChatHub> HubContext { get; set; }
        private UserManager<AppUser> UserManager { get; set; }
        private RoleManager<IdentityRole> RoleManager { get; set; }
        private IMapper Mapper { get; set; }

        public GroupController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
            UserManager = userManager;
            RoleManager = roleManager;
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


        public async Task<IActionResult> EditGroupMember(string memberId, int chatId)
        {
            return View
                (
                   new EditMemberViewModel
                   {
                       ChatId = chatId,
                       AppUser = await UserManager.FindByIdAsync(memberId),
                       Roles = RoleManager.Roles.ToList()
                   }           
                );
        }


        [HttpPost]
        public async Task<JsonResult> EditGroupMember(EditGroupMemberDto editGroupMemberDto)
        {
            try
            {
                if(editGroupMemberDto.Kick)
                {
                    UnitOfWork.UserChatRepo.DeleteEntry(editGroupMemberDto.ChatId);

                    BannMember groupMember = new BannMember
                    {
                        ChatId = editGroupMemberDto.ChatId,
                        AppUserId = editGroupMemberDto.MemberId,
                        BannTypeId = UnitOfWork.BannTypeRepo.GetBannTypeId("Group"),
                        IssuedById = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };

                    await UnitOfWork.BannMemberRepo.AddAsync(groupMember);
                    await UnitOfWork.SaveChangesAsync();
                }
                else
                {
                   await UserManager.AddToRoleAsync(
                       await UserManager.FindByIdAsync(editGroupMemberDto.MemberId), editGroupMemberDto.RoleName);
                }
            }
            catch
            {
                return new JsonResult("Changes not applied, something went wrong!");
            }

            return new JsonResult("Changes applied successfuly.");
        }
    }
}
