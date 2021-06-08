using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class MadeGroupIDNullableInMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ForumGroupId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ForumGroupId",
                table: "AspNetUsers",
                column: "ForumGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Groups_ForumGroupId",
                table: "AspNetUsers",
                column: "ForumGroupId",
                principalTable: "Groups",
                principalColumn: "ForumGroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Groups_ForumGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ForumGroupId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ForumGroupId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
