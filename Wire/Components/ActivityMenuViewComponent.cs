using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wire.Data.Repository.UnitOfWork;
using Wire.Models.ViewModels;

namespace Wire.Components
{
    public class ActivityMenuViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;

        public ActivityMenuViewComponent(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            string userId = UserClaimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

            return View
                (
                   new ActiveChatViewModel
                   {
                       ActiveChats = UnitOfWork.ActiveChatRepo
                        .GetGroupActiveChats(userId),
                       Groups = UnitOfWork.UserChatRepo.GetGroups(userId)
                   }

               );
        }
    }
}
