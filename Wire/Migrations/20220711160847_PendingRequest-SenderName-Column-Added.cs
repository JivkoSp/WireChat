using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class PendingRequestSenderNameColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "PendingRequest",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "PendingRequest");
        }
    }
}
