using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCartUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc4ef19a-b2ed-45cc-bea5-848c74958306", "AQAAAAIAAYagAAAAEBmpJPvPqV+2e/I8hV/cbg7yctCEnjTW1AdYWZB54dkF4tma1wGqCYmn24B80q/2Hw==", "bd01cf80-165b-488c-b88b-4ec5ca3c5ac0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed931a14-e3ff-4e27-97e6-f045f09be71e", "AQAAAAIAAYagAAAAEON2ZLKivoyN5Rqode4n3a7u5fBrZmxs/vwkm2uTtY/ohmrM8mflWImJCYo74dSePg==", "32d1215e-16ff-406e-9c69-576bc0ac025d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f9c6ae1-2372-415c-821f-338420cd8f19", "AQAAAAIAAYagAAAAENQ3yhvK25p2P0lzTRquUKBciKuKx/PiCPsHBX8yOf7oO4m5TFOWlKf0+9Ud2Bdliw==", "77696f8e-becd-4685-a1ec-ed761341b2bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c6abdd-3ca9-4726-a884-0c1258a92822", "AQAAAAIAAYagAAAAEMBvqMpOXEmhI9xwBYnfezbF6Hwab40IAsFJORhJxC8gOa7nW1bQOQu4IhUimINPXw==", "cda17589-b8a8-437d-bee2-2ed2ce732452" });
        }
    }
}
