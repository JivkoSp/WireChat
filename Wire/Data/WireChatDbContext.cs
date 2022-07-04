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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>(builder => {

                builder.ToTable("AppUser");
            });

            modelBuilder.Entity<Chat>(builder => {

                builder.ToTable("Chat");

                builder.HasOne(prop => prop.ChatTopic)
                .WithOne(prop => prop.Chat)
                .HasForeignKey<ChatTopic>(prop => prop.ChatId)
                .HasConstraintName("FK_Chat_ChatTopic");
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

                builder.HasOne(prop => prop.Chat)
                .WithOne(prop => prop.ChatType)
                .HasForeignKey<Chat>(prop => prop.ChatTypeId)
                .HasConstraintName("FK_ChatType_Chat");
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

                builder.Property(prop => prop.DateTime)
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
                .HasForeignKey(prop => prop.SenderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AppUser_PendingRequests");
            });

            modelBuilder.Entity<UserChat>(builder => {

                builder.ToTable("UserChat");

                builder.HasKey(prop => new { prop.AppUserId, prop.ChatId });

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
        }
    }
}
