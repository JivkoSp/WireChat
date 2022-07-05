using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Interfaces;

namespace Wire.Data.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAppUserRepo UserRepo { get; }
        IPendingRequestRepo PendingRequestRepo { get; }
        Task SaveChangesAsync();
    }
}
