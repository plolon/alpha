using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatformService.Migrations
{
    public partial class SeedPlatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "platforms",
                columns: new[] { "Id", "Cost", "Name", "Publisher" },
                values: new object[] { 1, "Free", ".Net", "Microsoft" });

            migrationBuilder.InsertData(
                table: "platforms",
                columns: new[] { "Id", "Cost", "Name", "Publisher" },
                values: new object[] { 2, "Free", "Sql Server Express", "Microsoft" });

            migrationBuilder.InsertData(
                table: "platforms",
                columns: new[] { "Id", "Cost", "Name", "Publisher" },
                values: new object[] { 3, "Free", "Kubernetes", "Cloud Native Computing Foundation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "platforms",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
