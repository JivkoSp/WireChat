using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class ActiveChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveChat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveChat", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chat_ActiveChat",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveChat");
        }
    }
}
