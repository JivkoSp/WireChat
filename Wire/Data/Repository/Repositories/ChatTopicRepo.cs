using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class ChatTopicRepo : GenericRepo<ChatTopic>, IChatTopicRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public ChatTopicRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public IEnumerable<ChatTopic> GetChatTopics(int chatId)
        {
            return WireChatDbContext.ChatTopics.Where(ch => ch.ChatId == chatId);
        }
    }
}
