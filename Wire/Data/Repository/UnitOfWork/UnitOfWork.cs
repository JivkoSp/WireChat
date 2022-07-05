using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Interfaces;

namespace Wire.Data.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private WireChatDbContext WireChatDbContext;
        public IAppUserRepo UserRepo { get; private set; }
        public IPendingRequestRepo PendingRequestRepo { get; private set; }

        public UnitOfWork(WireChatDbContext dbContext, IAppUserRepo userRepo, IPendingRequestRepo pendingRequestRepo)
        {
            WireChatDbContext = dbContext;
            UserRepo = userRepo;
            PendingRequestRepo = pendingRequestRepo;
        }

        public async Task SaveChangesAsync()
        {
            await WireChatDbContext.SaveChangesAsync();
        }
    }
}
