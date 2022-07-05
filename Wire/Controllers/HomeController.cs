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

namespace Wire.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<AppUser> UserManager;
        private IUnitOfWork UnitOfWork;
        private IHubContext<NotificationHub> HubContext;

        public HomeController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
            IHubContext<NotificationHub> hubContext)
        {
            UserManager = userManager;
            UnitOfWork = unitOfWork;
            HubContext = hubContext;
        }

        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest(string userName)
        {
            try
            {
                var senderId = UserManager.GetUserId(User);
                var receiver = await UserManager.FindByNameAsync(userName);

                if(!UnitOfWork.UserRepo.isFriend(senderId, receiver.Id))
                {
                    PendingRequest pendingRequest = new PendingRequest
                    {
                        SenderId = senderId,
                        ReceiverId = receiver.Id,
                        ChatType = "Private"
                    };

                    await UnitOfWork.PendingRequestRepo.AddAsync(pendingRequest);
                    await UnitOfWork.SaveChangesAsync();

                    //Call notification hub
                    await HubContext.Clients.User(receiver.Id).SendAsync("PendingRequestReceived", pendingRequest);
                }
            }
            catch
            {
                Console.WriteLine("error");
            }

            return RedirectToAction("HomePage");
        }

        public IActionResult PendingRequests()
        {
            return View(UnitOfWork.PendingRequestRepo.GetPendingRequests());
        }

    }
}
