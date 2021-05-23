using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class changedThreadTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreadUser");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Threads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Threads",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Threads_UserId",
                table: "Threads",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threads_AspNetUsers_UserId",
                table: "Threads");

            migrationBuilder.DropIndex(
                name: "IX_Threads_UserId",
                table: "Threads");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Threads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ThreadUser",
                columns: table => new
                {
                    ThreadsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreadUser", x => new { x.ThreadsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ThreadUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThreadUser_Threads_ThreadsId",
                        column: x => x.ThreadsId,
                        principalTable: "Threads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "Id", "DateCreated", "Description", "IsSticky", "PostId", "SubCategoryId", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Local), "", false, 1, 1, "Vilken Volvo bil ska jag köpa!?", "3a37b34f-e1d2-47f5-aba6-a75e62e538e7" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "DatePosted", "IsReported", "PostText", "ThreadId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 20, 9, 47, 23, 655, DateTimeKind.Local).AddTicks(3431), false, "Jag har funderat på att köpa S90 men den verkar vara dyr har någon erfarenhet av denna model?", 1, "3a37b34f-e1d2-47f5-aba6-a75e62e538e7" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "DatePosted", "IsReported", "PostText", "ThreadId", "UserId" },
                values: new object[] { 2, new DateTime(2021, 5, 20, 9, 47, 23, 655, DateTimeKind.Local).AddTicks(5219), false, "Just det jag glömde säga att V60 modelen också är intressant, sry för dubbel post", 1, "3a37b34f-e1d2-47f5-aba6-a75e62e538e7" });

            migrationBuilder.CreateIndex(
                name: "IX_ThreadUser_UsersId",
                table: "ThreadUser",
                column: "UsersId");
        }
    }
}
