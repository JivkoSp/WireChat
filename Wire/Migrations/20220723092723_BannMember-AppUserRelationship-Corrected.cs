using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannMemberAppUserRelationshipCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannMember_AppUser_AppUserId",
                table: "BannMember");

            migrationBuilder.DropIndex(
                name: "IX_BannMember_AppUserId",
                table: "BannMember");

            migrationBuilder.CreateIndex(
                name: "IX_BannMember_AppUserId",
                table: "BannMember",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_BannMembers",
                table: "BannMember",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_BannMembers",
                table: "BannMember");

            migrationBuilder.DropIndex(
                name: "IX_BannMember_AppUserId",
                table: "BannMember");

            migrationBuilder.CreateIndex(
                name: "IX_BannMember_AppUserId",
                table: "BannMember",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BannMember_AppUser_AppUserId",
                table: "BannMember",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
