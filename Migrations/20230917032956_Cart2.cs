using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Cart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1dc83e7-ecd5-461a-8860-f9e14fd79ebc", "AQAAAAIAAYagAAAAEPIyBBA3cR1ALBeHn45Phoe7MP3R7YSoVb5HwI+KoPXoWAfFyOvkZZzECqVYwNramw==", "e7853883-5eee-4477-a93a-de5648be5276" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3642d06-e4ca-430c-a31c-9af5b85d3a97", "AQAAAAIAAYagAAAAEH91nZns38Gp6nnaw+p0d1asG4nKDqQIrLiC6Oz6qWbSC7LfmF/aeibfcw3nkRMRsA==", "0b14074c-4bc9-4f9b-b329-e386f0de4376" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9c459a8-7580-46ac-8bc2-c590d1feade0", "AQAAAAIAAYagAAAAEHdht2MdCiEFDf9hDiwFlG9FgQ2/idUR/IQy8ekXE4ZqJsJNgV1+VjmEuMH6HWpAVQ==", "44ffb1c3-674e-4c8e-9094-ed2133328424" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8959286b-c9ce-4921-a9d9-788b870ac02c", "AQAAAAIAAYagAAAAEK6NoxA6MzZ8ccDNnowo6j1wfIXTsQYatcj7QxQpXpDaMsc6bkPHyxRV9guWuBX9Og==", "f9324a3d-13d3-4740-b2e1-3ffa59794b6f" });
        }
    }
}
