using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class AddedAdminIdToGroupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Groups");
        }
    }
}
