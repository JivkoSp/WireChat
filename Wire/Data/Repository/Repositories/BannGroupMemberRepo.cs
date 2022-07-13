using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class BannGroupMemberRepo : GenericRepo<BannGroupMember>, IBannGroupMemberRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public BannGroupMemberRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public bool isUserBanned(int chadId, string userId)
        {
            return WireChatDbContext.BannGroupMembers.Where(u => u.ChatId == chadId)
                .FirstOrDefault(u => u.AppUserId == userId) != null ? true : false;
        }           
    }
}
