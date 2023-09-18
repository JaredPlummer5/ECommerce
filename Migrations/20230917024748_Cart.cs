using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4403b35f-b7e6-4f12-83f5-cb575d2d1d66", "AQAAAAIAAYagAAAAEMFElxKFnZaBf7T9n4tObiRkM6R/ez0/2iUtZ3OSZI3F8P/Xx6Ds4OW/QzDhzcr3/A==", "e341b348-e226-4680-949c-d6abd299def2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f387124-95cc-4260-9153-16db114317a9", "AQAAAAIAAYagAAAAEEyia8DvEN0EtRu36hjy4WjuqqxIVjK9NfZheAdKtOozHFTk46bc6kGkdAw1OAD/4Q==", "e48b8709-d3ed-481d-8a39-6a861c8e8b67" });
        }
    }
}
