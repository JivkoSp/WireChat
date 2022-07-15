using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class MessageTimeToLiveAnonymUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnonymUser",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnonymUser", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUser_AnonymUser",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageTimeToLive",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LifeSpan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTimeToLive", x => x.AppUserId);
                    table.ForeignKey(
                        name: "FK_AppUser_MessageTimeToLive",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnonymUser");

            migrationBuilder.DropTable(
                name: "MessageTimeToLive");
        }
    }
}
