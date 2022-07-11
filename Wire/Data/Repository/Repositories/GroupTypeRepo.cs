using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class GroupTypeRepo : GenericRepo<GroupType>, IGroupTypeRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public GroupTypeRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public List<GroupType> GetGroupTypes()
        {
            return WireChatDbContext.GroupTypes.ToList();
        }
    }
}
