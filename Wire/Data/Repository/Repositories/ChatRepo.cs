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
    public class ChatRepo : GenericRepo<Chat>, IChatRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public ChatRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public Chat GetChat(int chatId)
        {
            return WireChatDbContext.Chats.Where(prop => prop.ChatId == chatId)
                    .Include(prop => prop.Group).FirstOrDefault();
        }
    }
}
