using Microsoft.EntityFrameworkCore.Migrations;

namespace Wire.Migrations
{
    public partial class GroupGroupTypeChatTypeRelationshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatType_Groups",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_ChatTypeId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ChatTypeId",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "GroupTypeId",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Group_ChatId",
                table: "Group",
                column: "ChatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Chat",
                table: "Group",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "ChatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Chat",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_ChatId",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Group");

            migrationBuilder.AlterColumn<int>(
                name: "GroupTypeId",
                table: "Group",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ChatTypeId",
                table: "Group",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Group_ChatTypeId",
                table: "Group",
                column: "ChatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatType_Groups",
                table: "Group",
                column: "ChatTypeId",
                principalTable: "ChatType",
                principalColumn: "ChatTypeId");
        }
    }
}
