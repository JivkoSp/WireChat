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

        public List<UserChat> GetFriendsWithChats(string userId)
        {
            return WireChatDbContext.Friends.Where(u => u.SenderId == userId)
                    .Include(u => u.AppUser)
                    .ThenInclude(u => u.UserChats.Where(chat => chat.ChatId == WireChatDbContext.ChatTypes
                    .Where(ch => ch.ChatName == "Private").Select(ch => ch.ChatTypeId).FirstOrDefault()))
                    .ThenInclude(ursChat => ursChat.AppUser)
                    .Select(u => u.AppUser.UserChats).FirstOrDefault().ToList();
        }

        public IEnumerable<Group> GetGroups(string userId)
        {
            return WireChatDbContext.UserChats.Where(u => u.AppUserId == userId)
                    .Include(u => u.Chat)
                    .ThenInclude(u => u.Group)
                    .Where(u => u.Chat.Group != null)
                    .Select(u => u.Chat.Group);
        }
    }
}
