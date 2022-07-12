using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class GroupPendingRequestRepo : GenericRepo<GroupPendingRequest>, IGroupPendingRequestRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public GroupPendingRequestRepo(WireChatDbContext dbContext):base(dbContext)
        {
        }

        public GroupPendingRequest GetGroupPendingRequest(int pendingRequestId)
        {
            return WireChatDbContext.GroupPendingRequests.Find(pendingRequestId);
        }
    }
}
