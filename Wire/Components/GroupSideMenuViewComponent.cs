using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;
using Wire.Models.ViewModels;

namespace Wire.Components
{
    public class GroupSideMenuViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;
        private UserManager<AppUser> UserManager;

        public GroupSideMenuViewComponent(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
        }

        public IViewComponentResult Invoke(int ChatId)
        {
            string userId = UserManager.GetUserId(UserClaimsPrincipal);

            return View
                (
                    new GroupSideMenuViewModel
                    {
                        UserId = userId,
                        ChatTopics = UnitOfWork.ChatTopicRepo.GetChatTopics(ChatId),
                        Contacts = UnitOfWork.UserChatRepo.GetFriendsWithChats(userId)
                    }      
                );
        }
    }
}
