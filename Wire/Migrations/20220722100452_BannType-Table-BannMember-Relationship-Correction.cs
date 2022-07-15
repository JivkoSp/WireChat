using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannTypeTableBannMemberRelationshipCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannGroupMember");

            migrationBuilder.CreateTable(
                name: "BannType",
                columns: table => new
                {
                    BannTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannType", x => x.BannTypeId);
                });

            migrationBuilder.CreateTable(
                name: "BannMember",
                columns: table => new
                {
                    BannMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BannTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannMember", x => x.BannMemberId);
                    table.ForeignKey(
                        name: "FK_BannMember_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BannMember_BannType_BannTypeId",
                        column: x => x.BannTypeId,
                        principalTable: "BannType",
                        principalColumn: "BannTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_BannMember",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannMember_AppUserId",
                table: "BannMember",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BannMember_BannTypeId",
                table: "BannMember",
                column: "BannTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BannMember_ChatId",
                table: "BannMember",
                column: "ChatId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannMember");

            migrationBuilder.DropTable(
                name: "BannType");

            migrationBuilder.CreateTable(
                name: "BannGroupMember",
                columns: table => new
                {
                    BannGroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannGroupMember", x => x.BannGroupMemberId);
                    table.ForeignKey(
                        name: "FK_Chat_BannGroupMembers",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BannGroupMember_ChatId",
                table: "BannGroupMember",
                column: "ChatId");
        }
    }
}
