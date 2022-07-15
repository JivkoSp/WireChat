using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannMemberRelationshipCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannMember_BannType_BannTypeId",
                table: "BannMember");

            migrationBuilder.AddForeignKey(
                name: "FK_BannType_BannMembers",
                table: "BannMember",
                column: "BannTypeId",
                principalTable: "BannType",
                principalColumn: "BannTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannType_BannMembers",
                table: "BannMember");

            migrationBuilder.AddForeignKey(
                name: "FK_BannMember_BannType_BannTypeId",
                table: "BannMember",
                column: "BannTypeId",
                principalTable: "BannType",
                principalColumn: "BannTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
