using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wire.Controllers
{
    public class ChatController : Controller
    {
        [HttpPost]
        public void CreatePrivateChat(string senderId, string receiverId)
        {
            
        }
    }
}
