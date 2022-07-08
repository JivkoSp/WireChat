using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class ChatTypeRepo : GenericRepo<ChatType>, IChatTypeRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public ChatTypeRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public int GetChatTypeId(string type)
        {
            return WireChatDbContext.ChatTypes.Where(ch => ch.ChatName == type)
                .Select(ch => ch.ChatTypeId).FirstOrDefault();
        }
    }
}
