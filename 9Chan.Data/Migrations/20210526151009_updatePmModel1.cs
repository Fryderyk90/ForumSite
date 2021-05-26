using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class updatePmModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PersonalMessages",
                newName: "FromUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "PersonalMessages",
                newName: "UserId");
        }
    }
}
