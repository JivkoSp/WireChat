using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class MessageTimeToLiveRepo : GenericRepo<MessageTimeToLive>, IMessageTimeToLiveRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public MessageTimeToLiveRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public MessageTimeToLive FindMessage(string userId)
        {
            return WireChatDbContext.MessageTimeToLives.FirstOrDefault(u => u.AppUserId == userId);
        }
    }
}
