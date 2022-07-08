using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class MessageRepo : GenericRepo<Message>, IMessageRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public MessageRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public List<Message> GetMessages(int chatId)
        {
            return WireChatDbContext.Messages.Where(m => m.ChatId == chatId).ToList();
        }
    }
}
