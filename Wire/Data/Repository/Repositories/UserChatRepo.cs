using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class UserChatRepo : GenericRepo<UserChat>, IUserChatRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public UserChatRepo(WireChatDbContext dbContext) : base(dbContext) 
        {
        }

        public List<UserChat> GetContactFriends(string userId)
        {
            try
            {
                return  WireChatDbContext.UserChats
                    .Include(u => u.Chat)
                    .ThenInclude(chat => chat.ChatType)
                    .Where(u => u.AppUserId == userId && u.Chat.ChatType.ChatName == "Private")
                    .Join(WireChatDbContext.UserChats, u => u.ChatId, f => f.ChatId,
                        (u, f) => new { User = u, Friend = f })
                    .Where(c => c.Friend.AppUserId != c.User.AppUserId)
                    .Select(chats => chats.Friend).Include(chats => chats.AppUser)
                    .ToList();
            }           
            catch
            {
                return new List<UserChat>();
            }
        }

        public IEnumerable<Group> GetGroups(string userId)
        {
            return WireChatDbContext.UserChats.Where(u => u.AppUserId == userId)
                    .Include(u => u.Chat)
                    .ThenInclude(u => u.Group)
                    .Where(u => u.Chat.Group != null)
                    .Select(u => u.Chat.Group);
        }

        public bool isMember(string userId, int chatId)
        {
            return WireChatDbContext.UserChats.Where(c => c.ChatId == chatId)
                    .FirstOrDefault(u => u.AppUserId == userId) != null ? true : false;
        }
    }
}
