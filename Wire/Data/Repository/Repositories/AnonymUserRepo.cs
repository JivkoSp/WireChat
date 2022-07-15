using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class AnonymUserRepo : GenericRepo<AnonymUser>, IAnonymUserRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public AnonymUserRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public bool isUserAnonymous(string userId)
        {
            return WireChatDbContext.AnonymUsers
                .FirstOrDefault(u => u.AppUserId == userId) != null ? true : false;
        }
    }
}
