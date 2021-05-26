using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class updatePmModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalMessageId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonalMessageId",
                table: "AspNetUsers",
                column: "PersonalMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonalMessages_PersonalMessageId",
                table: "AspNetUsers",
                column: "PersonalMessageId",
                principalTable: "PersonalMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonalMessages_PersonalMessageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonalMessageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalMessageId",
                table: "AspNetUsers");
        }
    }
}
