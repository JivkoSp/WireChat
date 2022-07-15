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
        IFriendRepo FriendRepo { get; }
        IChatTypeRepo ChatTypeRepo { get; }
        IChatRepo ChatRepo { get; }
        IUserChatRepo UserChatRepo { get; }
        IMessageRepo MessageRepo { get; }
        IGroupTypeRepo GroupTypeRepo { get; }
        IChatTopicRepo ChatTopicRepo { get; }
        IGroupPendingRequestRepo GroupPendingRequestRepo { get; }
        IGroupRepo GroupRepo { get; }
        IBannGroupMemberRepo BannGroupMemberRepo { get; }
        IMessageTimeToLiveRepo MessageTimeToLiveRepo { get; }
        IAnonymUserRepo AnonymUserRepo { get; }
        IProfilePictureRepo ProfilePictureRepo { get; }
        Task SaveChangesAsync();
    }
}
