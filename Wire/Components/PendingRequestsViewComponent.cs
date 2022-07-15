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
    public class PendingRequestsViewComponent : ViewComponent
    {
        private IUnitOfWork UnitOfWork;
        private UserManager<AppUser> UserManager;

        public PendingRequestsViewComponent(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            UnitOfWork = unitOfWork;
            UserManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await UserManager.GetUserAsync(UserClaimsPrincipal);
            return View(UnitOfWork.PendingRequestRepo.GetPendingRequests(user.Id).Count());
        }
    }
}
