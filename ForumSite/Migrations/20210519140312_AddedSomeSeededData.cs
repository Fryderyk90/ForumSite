using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForumSite.Migrations
{
    public partial class AddedSomeSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Thread",
                columns: new[] { "Id", "DateCreated", "Description", "IsSticky", "PostId", "SubCategoryId", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Local), "", false, 1, 1, "Vilken Volvo bil ska jag köpa!?", "e4e322dd-aed7-4ba3-825b-a4b5097428e4" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "DatePosted", "IsReported", "PostText", "ThreadId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 19, 16, 3, 11, 480, DateTimeKind.Local).AddTicks(7488), false, "Jag har funderat på att köpa S90 men den verkar vara dyr har någon erfarenhet av denna model?", 1, "e4e322dd-aed7-4ba3-825b-a4b5097428e4" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "DatePosted", "IsReported", "PostText", "ThreadId", "UserId" },
                values: new object[] { 2, new DateTime(2021, 5, 19, 16, 3, 11, 480, DateTimeKind.Local).AddTicks(8949), false, "Just det jag glömde säga att V60 modelen också är intressant, sry för dubbel post", 1, "e4e322dd-aed7-4ba3-825b-a4b5097428e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Thread",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
