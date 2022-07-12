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
    public class SideMenuViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;
        private UserManager<AppUser> UserManager;

        public SideMenuViewComponent(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
        }

        public IViewComponentResult Invoke(string RoomType = null)
        {
            return View
                (
                    new SideMenuViewModel
                    {
                        RoomType = RoomType,
                        Contacts = UnitOfWork.UserChatRepo.GetContactFriends(UserManager.GetUserId(UserClaimsPrincipal))
                    }
                );
        }
    }
}
