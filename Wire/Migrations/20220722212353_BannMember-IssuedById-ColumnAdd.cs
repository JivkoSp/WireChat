using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class BannMemberIssuedByIdColumnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssuedById",
                table: "BannMember",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssuedById",
                table: "BannMember");
        }
    }
}
