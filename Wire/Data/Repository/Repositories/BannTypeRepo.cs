using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class BannTypeRepo : GenericRepo<BannType>, IBannTypeRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public BannTypeRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public int GetBannTypeId(string type)
        {
            return WireChatDbContext.BannTypes.Where(prop => prop.Type == type)
                    .Select(prop => prop.BannTypeId).FirstOrDefault();
        }
    }
}
