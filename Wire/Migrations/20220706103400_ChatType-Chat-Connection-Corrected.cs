using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class ChatTypeChatConnectionCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatType_Chat",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat",
                column: "ChatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatType_Chats",
                table: "Chat",
                column: "ChatTypeId",
                principalTable: "ChatType",
                principalColumn: "ChatTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatType_Chats",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_ChatTypeId",
                table: "Chat",
                column: "ChatTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatType_Chat",
                table: "Chat",
                column: "ChatTypeId",
                principalTable: "ChatType",
                principalColumn: "ChatTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
