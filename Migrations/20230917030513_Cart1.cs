using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Cart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4721ae25-c2f0-4981-abef-0ccd37e773af", "AQAAAAIAAYagAAAAELUt6YfsJ+lrNuu/1tiU+qBr5QUY8ZvLie7nM0bav6GWBzentsdr5L/8qNAkadQu+Q==", "f7498ebe-8dca-4614-b662-74431c50f35f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e779b911-bfd4-4e12-8e55-80da292f3dbd", "AQAAAAIAAYagAAAAEJRX4i3wnu42QNA5TlJHaUDo8TWZFczUMz2VWC2546wCWnZADrEMscRoDV4eZdTt4g==", "fca51a7b-5993-4155-a65c-0e7867dea049" });
        }
    }
}
