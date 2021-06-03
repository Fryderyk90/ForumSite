using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class AddedThreadIdToLikesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThreadId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "Likes");
        }
    }
}
