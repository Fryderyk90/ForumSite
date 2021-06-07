using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class AddedGroupMessageIdToMessageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonalMessages_PersonalMessageId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PersonalMessages");

            migrationBuilder.RenameColumn(
                name: "PersonalMessageId",
                table: "AspNetUsers",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PersonalMessageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_MessageId");

            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "UserGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_MessageId",
                table: "UserGroups",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Messages_MessageId",
                table: "AspNetUsers",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Messages_MessageId",
                table: "UserGroups",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Messages_MessageId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Messages_MessageId",
                table: "UserGroups");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_UserGroups_MessageId",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "AspNetUsers",
                newName: "PersonalMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_MessageId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PersonalMessageId");

            migrationBuilder.CreateTable(
                name: "PersonalMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMessages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonalMessages_PersonalMessageId",
                table: "AspNetUsers",
                column: "PersonalMessageId",
                principalTable: "PersonalMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
