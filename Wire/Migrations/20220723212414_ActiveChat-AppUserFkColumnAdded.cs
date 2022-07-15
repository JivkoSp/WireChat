using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class ActiveChatAppUserFkColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ActiveChat",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActiveChat_AppUserId",
                table: "ActiveChat",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_ActiveChats",
                table: "ActiveChat",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_ActiveChats",
                table: "ActiveChat");

            migrationBuilder.DropIndex(
                name: "IX_ActiveChat_AppUserId",
                table: "ActiveChat");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ActiveChat");
        }
    }
}
