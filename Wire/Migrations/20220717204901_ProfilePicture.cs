using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class ProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilePictureId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                columns: table => new
                {
                    ProfilePictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicture", x => x.ProfilePictureId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_ProfilePictureId",
                table: "AppUser",
                column: "ProfilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePicture_AppUsers",
                table: "AppUser",
                column: "ProfilePictureId",
                principalTable: "ProfilePicture",
                principalColumn: "ProfilePictureId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePicture_AppUsers",
                table: "AppUser");

            migrationBuilder.DropTable(
                name: "ProfilePicture");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_ProfilePictureId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "AppUser");
        }
    }
}
