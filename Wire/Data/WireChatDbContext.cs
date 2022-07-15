using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wire.Models;

namespace Wire.Data
{
    public class WireChatDbContext : IdentityDbContext<AppUser>
    {
        public WireChatDbContext(DbContextOptions<WireChatDbContext> options):base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatTopic> ChatTopics { get; set; }
        public virtual DbSet<ChatType> ChatTypes { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<PendingRequest> PendingRequests { get; set; }
        public virtual DbSet<UserChat> UserChats { get; set; }
        public virtual DbSet<GroupType> GroupTypes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupPendingRequest> GroupPendingRequests { get; set; }
        public virtual DbSet<BannType> BannTypes { get; set; }
        public virtual DbSet<BannMember> BannMembers { get; set; }
        public virtual DbSet<MessageTimeToLive> MessageTimeToLives { get; set; }
        public virtual DbSet<AnonymUser> AnonymUsers { get; set; }
        public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }
        public virtual DbSet<ActiveChat> ActiveChats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(builder => {

                builder.ToTable("AppUser");

                builder.HasOne(prop => prop.ProfilePicture)
                .WithMany(prop => prop.AppUsers)
                .HasForeignKey(prop => prop.ProfilePictureId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_ProfilePicture_AppUsers");
            });

            modelBuilder.Entity<Chat>(builder => {

                builder.ToTable("Chat");

                builder.HasOne(prop => prop.ChatTopic)
                .WithOne(prop => prop.Chat)
                .HasForeignKey<ChatTopic>(prop => prop.ChatId)
                .HasConstraintName("FK_Chat_ChatTopic");

                builder.HasOne(prop => prop.ChatType)
                .WithMany(prop => prop.Chats)
                .HasForeignKey(prop => prop.ChatTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChatType_Chats");
            });

            modelBuilder.Entity<ChatTopic>(builder => {

                builder.ToTable("ChatTopic");

                builder.Property(prop => prop.TopicName)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<ChatType>(builder => {

                builder.ToTable("ChatType");

                builder.Property(prop => prop.ChatName)
                .HasMaxLength(50)
                .IsRequired();
            });

            modelBuilder.Entity<Friend>(builder => {

                builder.ToTable("Friend");

                builder.HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.Friends)
                .HasForeignKey(prop => prop.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_Friends");
            });

            modelBuilder.Entity<Message>(builder => {

                builder.ToTable("Message");

                builder.Property(prop => prop.Publisher)
                    .HasMaxLength(100)
                    .IsRequired();

                builder.Property(prop => prop.DateTime)
                    .HasColumnType("datetime2")
                    .IsRequired();

                builder.Property(prop => prop.MessageLifeTime)
                  .HasColumnType("datetime2")
                  .IsRequired();

                builder.HasOne(prop => prop.Chat)
                .WithMany(prop => prop.Messages)
                .HasForeignKey(prop => prop.ChatId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Chat_Messages");
            });

            modelBuilder.Entity<PendingRequest>(builder => {

                builder.ToTable("PendingRequest");

                builder.Property(prop => prop.ChatType)
                    .HasMaxLength(50)
                    .IsRequired();

                builder.HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.PendingRequests)
                .HasForeignKey(prop => prop.ReceiverId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_PendingRequests");
            });

            modelBuilder.Entity<UserChat>(builder => {

                builder.ToTable("UserChat");

                builder.HasKey(prop => new { prop.AppUserId, prop.ChatId });

                builder.Property(prop => prop.JoinDate)
                .HasColumnType("datetime2")
                .IsRequired();

                builder.HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.UserChats)
                .HasForeignKey(prop => prop.AppUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_UserChats");

                builder.HasOne(prop => prop.Chat)
                .WithMany(prop => prop.UserChats)
                .HasForeignKey(prop => prop.ChatId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Chat_UserChats");
            });

            modelBuilder.Entity<GroupType>(builder => {

                builder.ToTable("GroupType");

                builder.Property(prop => prop.GroupTypeName)
                .HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<Group>(builder => {

                builder.ToTable("Group");

                builder.Property(prop => prop.GroupName)
                .HasMaxLength(50).IsRequired();

                builder.HasOne(prop => prop.GroupType)
                .WithMany(prop => prop.Groups)
                .HasForeignKey(prop => prop.GroupTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_GroupType_Groups");

                builder.HasOne(prop => prop.Chat)
                .WithOne(prop => prop.Group)
                .HasForeignKey<Group>(prop => prop.ChatId)
                .HasConstraintName("FK_Group_Chat");
            });

            modelBuilder.Entity<GroupPendingRequest>(builder => {

                builder.ToTable("GroupPendingRequest");
                builder.HasKey(prop => prop.PendingRequestId);

                builder.HasOne(prop => prop.PendingRequest)
                .WithOne(prop => prop.GroupPendingRequest)
                .HasForeignKey<GroupPendingRequest>(prop => prop.PendingRequestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PendingRequest_GroupPendingRequest");

                builder.HasOne(prop => prop.Chat)
                .WithMany(prop => prop.GroupPendingRequests)
                .HasForeignKey(prop => prop.ChatId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Chat_GroupPendingRequest");
            });

            modelBuilder.Entity<BannType>(builder => {

                builder.ToTable("BannType");

                builder.Property(prop => prop.Type)
                  .HasMaxLength(50)
                  .IsRequired();
            });

            modelBuilder.Entity<BannMember>(builder => {

                builder.ToTable("BannMember");

                builder.HasIndex(prop => prop.IssuedById);

                builder.HasOne(prop => prop.BannType)
                .WithMany(prop => prop.BannMembers)
                .HasForeignKey(prop => prop.BannTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_BannType_BannMembers");

                builder.HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.BannMembers)
                .HasForeignKey(prop => prop.AppUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_BannMembers");
            });

            modelBuilder.Entity<MessageTimeToLive>(builder => {

                builder.ToTable("MessageTimeToLive");

                builder.HasKey(prop => prop.AppUserId);

                builder.HasOne(prop => prop.AppUser)
                 .WithOne(prop => prop.MessageTimeToLive)
                 .HasForeignKey<MessageTimeToLive>(prop => prop.AppUserId)
                 .OnDelete(DeleteBehavior.Cascade)
                 .HasConstraintName("FK_AppUser_MessageTimeToLive");
            });

            modelBuilder.Entity<AnonymUser>(builder => {

                builder.ToTable("AnonymUser");

                builder.HasKey(prop => prop.AppUserId);

                builder.HasOne(prop => prop.AppUser)
                .WithOne(prop => prop.AnonymUser)
                .HasForeignKey<AnonymUser>(prop => prop.AppUserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_AnonymUser");
            });

            modelBuilder.Entity<ProfilePicture>(builder => {

                builder.ToTable("ProfilePicture");

                builder.Property(p => p.Picture)
               .HasColumnType("image");
            });

            modelBuilder.Entity<ActiveChat>(builder => {

                builder.ToTable("ActiveChat");

                builder.HasKey(prop => prop.ChatId);

                builder.Property(prop => prop.DateTime)
                .HasColumnType("datetime2")
                .IsRequired();

                builder.HasOne(prop => prop.Chat)
                .WithOne(prop => prop.ActiveChat)
                .HasForeignKey<ActiveChat>(prop => prop.ChatId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Chat_ActiveChat");
            });
        }
    }
}
