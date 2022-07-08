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
        public ChatRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }
    }
}
