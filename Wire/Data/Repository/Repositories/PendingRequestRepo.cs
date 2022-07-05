using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Generic;
using Wire.Data.Repository.Interfaces;
using Wire.Models;

namespace Wire.Data.Repository.Repositories
{
    public class PendingRequestRepo : GenericRepo<PendingRequest>, IPendingRequestRepo
    {
        private WireChatDbContext WireChatDbContext => Context as WireChatDbContext;

        public PendingRequestRepo(WireChatDbContext dbContext) :base(dbContext)
        {
        }

        public List<PendingRequest> GetPendingRequests()
        {
            return WireChatDbContext.PendingRequests.ToList();
        }
    }
}
