using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models;

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

        public IViewComponentResult Invoke()
        {
            return View(UnitOfWork.UserChatRepo.GetFriendsWithChats(UserManager.GetUserId(UserClaimsPrincipal)));
        }
    }
}
