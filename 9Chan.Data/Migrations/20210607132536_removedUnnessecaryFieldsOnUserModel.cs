using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class removedUnnessecaryFieldsOnUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Messages_MessageId",
                table: "UserGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_MessageId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Groups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_MessageId",
                table: "Groups",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Messages_MessageId",
                table: "Groups",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Messages_MessageId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_MessageId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "UserGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreadId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_MessageId",
                table: "UserGroups",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Messages_MessageId",
                table: "UserGroups",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
