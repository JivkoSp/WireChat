using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannGroupMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BannGroupMember",
                columns: table => new
                {
                    BannGroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannGroupMember");
        }
    }
}
