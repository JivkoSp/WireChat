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
    public class FriendRepo : GenericRepo<Friend>, IFriendRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public FriendRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public bool isFriend(string senderId, string receiverId)
        {
            return WireChatDbContext.Friends.Where(u => u.SenderId == senderId)
                    .FirstOrDefault(f => f.ReceiverId == receiverId) != null ? true : false;
        }
    }
}
