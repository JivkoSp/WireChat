using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class PendingRequestFk_Corrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_PendingRequests",
                table: "PendingRequest");

            migrationBuilder.DropIndex(
                name: "IX_PendingRequest_SenderId",
                table: "PendingRequest");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "PendingRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "PendingRequest",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingRequest_ReceiverId",
                table: "PendingRequest",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_PendingRequests",
                table: "PendingRequest",
                column: "ReceiverId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_PendingRequests",
                table: "PendingRequest");

            migrationBuilder.DropIndex(
                name: "IX_PendingRequest_ReceiverId",
                table: "PendingRequest");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "PendingRequest",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "PendingRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingRequest_SenderId",
                table: "PendingRequest",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_PendingRequests",
                table: "PendingRequest",
                column: "SenderId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
