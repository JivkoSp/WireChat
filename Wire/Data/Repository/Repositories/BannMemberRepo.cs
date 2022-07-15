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
    public class BannMemberRepo : GenericRepo<BannMember>, IBannMemberRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public BannMemberRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public bool isUserBannedFromGroup(int chadId, string userId)
        {
            return WireChatDbContext.BannMembers.Where(u => u.ChatId == chadId)
                .FirstOrDefault(u => u.AppUserId == userId) != null ? true : false;
        }

        public IEnumerable<BannMember> GetBannMembers(string userId)
        {
            return WireChatDbContext.BannMembers.Where(prop => prop.IssuedById == userId)
                    .Include(prop => prop.AppUser)
                    .ThenInclude(prop => prop.ProfilePicture)
                    .Include(prop => prop.BannType);
        }

        public bool isUserBannedFromContact(string userId, string issuerId)
        {
            return WireChatDbContext.BannMembers.Where(prop => prop.IssuedById == issuerId)
                    .FirstOrDefault(prop => prop.AppUserId == userId) != null ? true : false;
        }
    }
}
