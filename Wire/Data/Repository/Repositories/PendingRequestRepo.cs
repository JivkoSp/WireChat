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

        public IEnumerable<PendingRequest> GetPendingRequests(string userId)
        {
            return WireChatDbContext.PendingRequests.Where(req => req.ReceiverId == userId);
        }

        public bool HavePendingRequest(string senderId, string receiverId)
        {
            return WireChatDbContext.PendingRequests.Where(s => s.ReceiverId == receiverId)
                    .FirstOrDefault(r => r.SenderId == senderId) != null ? true : false;
        }
    }
}
