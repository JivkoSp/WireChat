using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannMemberChatRelationshipRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_BannMember",
                table: "BannMember");

            migrationBuilder.DropIndex(
                name: "IX_BannMember_ChatId",
                table: "BannMember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BannMember_ChatId",
                table: "BannMember",
                column: "ChatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_BannMember",
                table: "BannMember",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
