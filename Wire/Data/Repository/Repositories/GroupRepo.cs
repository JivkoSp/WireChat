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
    public class GroupRepo : GenericRepo<Group>, IGroupRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public GroupRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public IEnumerable<UserChat> GetGroupMembers(int chatId)
        {
            return WireChatDbContext.UserChats.Where(userChat => userChat.ChatId == chatId)
                    .Include(u => u.AppUser);
        }
    }
}
