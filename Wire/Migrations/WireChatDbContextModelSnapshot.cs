﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wire.Data;

namespace Wire.Migrations
{
    [DbContext(typeof(WireChatDbContext))]
    partial class WireChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Wire.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Wire.Models.BannGroupMember", b =>
                {
                    b.Property<int>("BannGroupMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.HasKey("BannGroupMemberId");

                    b.HasIndex("ChatId");

                    b.ToTable("BannGroupMember");
                });

            modelBuilder.Entity("Wire.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatTypeId")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.HasIndex("ChatTypeId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("Wire.Models.ChatTopic", b =>
                {
                    b.Property<int>("ChatTopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ChatTopicId");

                    b.HasIndex("ChatId")
                        .IsUnique();

                    b.ToTable("ChatTopic");
                });

            modelBuilder.Entity("Wire.Models.ChatType", b =>
                {
                    b.Property<int>("ChatTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChatName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ChatTypeId");

                    b.ToTable("ChatType");
                });

            modelBuilder.Entity("Wire.Models.Friend", b =>
                {
                    b.Property<int>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Friend");
                });

            modelBuilder.Entity("Wire.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GroupTypeId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ChatId")
                        .IsUnique();

                    b.HasIndex("GroupTypeId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Wire.Models.GroupPendingRequest", b =>
                {
                    b.Property<int>("PendingRequestId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.HasKey("PendingRequestId");

                    b.HasIndex("ChatId")
                        .IsUnique();

                    b.ToTable("GroupPendingRequest");
                });

            modelBuilder.Entity("Wire.Models.GroupType", b =>
                {
                    b.Property<int>("GroupTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GroupTypeId");

                    b.ToTable("GroupType");
                });

            modelBuilder.Entity("Wire.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Wire.Models.PendingRequest", b =>
                {
                    b.Property<int>("PendingRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChatType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PendingRequestId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("PendingRequest");
                });

            modelBuilder.Entity("Wire.Models.UserChat", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AppUserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("UserChat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Wire.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wire.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wire.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wire.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wire.Models.BannGroupMember", b =>
                {
                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithMany("BannGroupMembers")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("FK_Chat_BannGroupMembers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Wire.Models.Chat", b =>
                {
                    b.HasOne("Wire.Models.ChatType", "ChatType")
                        .WithMany("Chats")
                        .HasForeignKey("ChatTypeId")
                        .HasConstraintName("FK_ChatType_Chats")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChatType");
                });

            modelBuilder.Entity("Wire.Models.ChatTopic", b =>
                {
                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithOne("ChatTopic")
                        .HasForeignKey("Wire.Models.ChatTopic", "ChatId")
                        .HasConstraintName("FK_Chat_ChatTopic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Wire.Models.Friend", b =>
                {
                    b.HasOne("Wire.Models.AppUser", "AppUser")
                        .WithMany("Friends")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK_AppUser_Friends")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Wire.Models.Group", b =>
                {
                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithOne("Group")
                        .HasForeignKey("Wire.Models.Group", "ChatId")
                        .HasConstraintName("FK_Group_Chat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wire.Models.GroupType", "GroupType")
                        .WithMany("Groups")
                        .HasForeignKey("GroupTypeId")
                        .HasConstraintName("FK_GroupType_Groups")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("GroupType");
                });

            modelBuilder.Entity("Wire.Models.GroupPendingRequest", b =>
                {
                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithOne("GroupPendingRequest")
                        .HasForeignKey("Wire.Models.GroupPendingRequest", "ChatId")
                        .HasConstraintName("FK_Chat_GroupPendingRequest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wire.Models.PendingRequest", "PendingRequest")
                        .WithOne("GroupPendingRequest")
                        .HasForeignKey("Wire.Models.GroupPendingRequest", "PendingRequestId")
                        .HasConstraintName("FK_PendingRequest_GroupPendingRequest")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("PendingRequest");
                });

            modelBuilder.Entity("Wire.Models.Message", b =>
                {
                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("FK_Chat_Messages")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Wire.Models.PendingRequest", b =>
                {
                    b.HasOne("Wire.Models.AppUser", "AppUser")
                        .WithMany("PendingRequests")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK_AppUser_PendingRequests")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Wire.Models.UserChat", b =>
                {
                    b.HasOne("Wire.Models.AppUser", "AppUser")
                        .WithMany("UserChats")
                        .HasForeignKey("AppUserId")
                        .HasConstraintName("FK_AppUser_UserChats")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wire.Models.Chat", "Chat")
                        .WithMany("UserChats")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("FK_Chat_UserChats")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Wire.Models.AppUser", b =>
                {
                    b.Navigation("Friends");

                    b.Navigation("PendingRequests");

                    b.Navigation("UserChats");
                });

            modelBuilder.Entity("Wire.Models.Chat", b =>
                {
                    b.Navigation("BannGroupMembers");

                    b.Navigation("ChatTopic");

                    b.Navigation("Group");

                    b.Navigation("GroupPendingRequest");

                    b.Navigation("Messages");

                    b.Navigation("UserChats");
                });

            modelBuilder.Entity("Wire.Models.ChatType", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("Wire.Models.GroupType", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Wire.Models.PendingRequest", b =>
                {
                    b.Navigation("GroupPendingRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
