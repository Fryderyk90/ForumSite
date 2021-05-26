using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class updatePmModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalMessages_AspNetUsers_UserId",
                table: "PersonalMessages");

            migrationBuilder.DropIndex(
                name: "IX_PersonalMessages_UserId",
                table: "PersonalMessages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUserId",
                table: "PersonalMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "PersonalMessages");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PersonalMessages",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMessages_UserId",
                table: "PersonalMessages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalMessages_AspNetUsers_UserId",
                table: "PersonalMessages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
