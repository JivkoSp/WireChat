using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class GroupPendingRequestChatRelationshipCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroupPendingRequest_ChatId",
                table: "GroupPendingRequest");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPendingRequest_ChatId",
                table: "GroupPendingRequest",
                column: "ChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GroupPendingRequest_ChatId",
                table: "GroupPendingRequest");

            migrationBuilder.CreateIndex(
                name: "IX_GroupPendingRequest_ChatId",
                table: "GroupPendingRequest",
                column: "ChatId",
                unique: true);
        }
    }
}
