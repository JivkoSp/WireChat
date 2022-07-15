using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class ActiveChatRepo : GenericRepo<ActiveChat>, IActiveChatRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public ActiveChatRepo(WireChatDbContext dbContext):base(dbContext)
        {             
        }

        public IEnumerable<ActiveChat> GetActiveChats(string userId)
        {
            var userChats = WireChatDbContext.UserChats
                .Where(prop => prop.AppUserId == userId)
                .Include(prop => prop.Chat).Select(prop => prop.Chat);

            return WireChatDbContext.ActiveChats.Where(prop => userChats.Contains(prop.Chat));
        }

        public IEnumerable<ActiveChat> GetGroupActiveChats(string userId)
        {
            var userChats = WireChatDbContext.UserChats
               .Where(prop => prop.AppUserId == userId)
               .Include(prop => prop.Chat).Select(prop => prop.Chat);

            return WireChatDbContext.ActiveChats
                .Include(prop => prop.Chat)
                .ThenInclude(prop => prop.Group)
                .Where(prop => userChats.Contains(prop.Chat) && prop.Chat.Group != null);
        }
    }
}
