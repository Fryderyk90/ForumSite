using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class AddedPictureFieldToCommentAndPostTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_ProfilePictures_ProfilePictureId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProfilePictureId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ProfilePictures");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProfilePictures",
                newName: "PostId");

            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "ProfilePictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "ProfilePictures");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "ProfilePictures",
                newName: "UserId");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "ProfilePictures",
                type: "varbinary(max)",
                nullable: true);

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
    }
}
