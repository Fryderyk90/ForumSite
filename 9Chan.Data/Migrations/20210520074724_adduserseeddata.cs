using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _9Chan.Data.Migrations
{
    public partial class adduserseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
