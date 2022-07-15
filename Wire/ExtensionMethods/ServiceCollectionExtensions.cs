using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wire.Data.Repository.Interfaces;
using Wire.Data.Repository.Repositories;
using Wire.Data.Repository.UnitOfWork;

namespace Wire.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAppUserRepo, AppUserRepo>();
            services.AddScoped<IPendingRequestRepo, PendingRequestRepo>();
            services.AddScoped<IFriendRepo, FriendRepo>();
            services.AddScoped<IChatTypeRepo, ChatTypeRepo>();
            services.AddScoped<IChatRepo, ChatRepo>();
            services.AddScoped<IUserChatRepo, UserChatRepo>();
            services.AddScoped<IMessageRepo, MessageRepo>();
            services.AddScoped<IGroupTypeRepo, GroupTypeRepo>();
            services.AddScoped<IChatTopicRepo, ChatTopicRepo>();
            services.AddScoped<IGroupPendingRequestRepo, GroupPendingRequestRepo>();
            services.AddScoped<IGroupRepo, GroupRepo>();
            services.AddScoped<IBannGroupMemberRepo, BannGroupMemberRepo>();
            services.AddScoped<IMessageTimeToLiveRepo, MessageTimeToLiveRepo>();
            services.AddScoped<IAnonymUserRepo, AnonymUserRepo>();
            services.AddScoped<IProfilePictureRepo, ProfilePictureRepo>();
        }
    }
}
