using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class addedProfilePictureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilePictureId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfilePictureId",
                table: "Posts",
                column: "ProfilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_ProfilePictures_ProfilePictureId",
                table: "Posts",
                column: "ProfilePictureId",
                principalTable: "ProfilePictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ProfilePictures_ProfilePictureId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProfilePictureId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "Posts");
        }
    }
}
