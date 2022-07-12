using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class GroupPendingRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChatType",
                table: "UserChat");

            migrationBuilder.CreateTable(
                name: "GroupPendingRequest",
                columns: table => new
                {
                    PendingRequestId = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPendingRequest", x => x.PendingRequestId);
                    table.ForeignKey(
                        name: "FK_Chat_GroupPendingRequest",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PendingRequest_GroupPendingRequest",
                        column: x => x.PendingRequestId,
                        principalTable: "PendingRequest",
                        principalColumn: "PendingRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPendingRequest_ChatId",
                table: "GroupPendingRequest",
                column: "ChatId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPendingRequest");

            migrationBuilder.AddColumn<string>(
                name: "ChatType",
                table: "UserChat",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
