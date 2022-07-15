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

        public IEnumerable<Friend> GetFriends(string userId)
        {
            return WireChatDbContext.Friends.Where(u => u.SenderId == userId)
                    .Include(u => u.AppUser);
        }

        public IEnumerable<AppUser> GetOnlineFriends(ICollection<AppUser> appUsers, string userId)
        {
            var friends = WireChatDbContext.Friends
                .Where(u => u.SenderId == userId).Include(u => u.AppUser)
                .ThenInclude(u => u.ProfilePicture);

            return friends.Where(prop => appUsers.Contains(prop.AppUser))
                .Select(prop => prop.AppUser);
        }

        public IEnumerable<Friend> GetFriendContact(string senderId, string receiverId)
        {
            return WireChatDbContext.Friends.Where(prop => prop.SenderId == senderId
            && prop.ReceiverId == receiverId || prop.SenderId == receiverId && prop.ReceiverId == senderId);
        }
    }
}
