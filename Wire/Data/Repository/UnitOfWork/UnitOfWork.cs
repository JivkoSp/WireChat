﻿using System;
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
        public IFriendRepo FriendRepo { get; private set; }
        public IChatTypeRepo ChatTypeRepo { get; private set; }
        public IChatRepo ChatRepo { get; private set; }
        public IUserChatRepo UserChatRepo { get; private set; }
        public IMessageRepo MessageRepo { get; private set; }

        public UnitOfWork(WireChatDbContext dbContext, IAppUserRepo userRepo, IPendingRequestRepo pendingRequestRepo,
            IFriendRepo friendRepo, IChatTypeRepo chatTypeRepo, IChatRepo chatRepo, IUserChatRepo userChatRepo,
            IMessageRepo messageRepo)
        {
            WireChatDbContext = dbContext;
            UserRepo = userRepo;
            PendingRequestRepo = pendingRequestRepo;
            FriendRepo = friendRepo;
            ChatTypeRepo = chatTypeRepo;
            ChatRepo = chatRepo;
            UserChatRepo = userChatRepo;
            MessageRepo = messageRepo;
        }

        public async Task SaveChangesAsync()
        {
            await WireChatDbContext.SaveChangesAsync();
        }
    }
}
