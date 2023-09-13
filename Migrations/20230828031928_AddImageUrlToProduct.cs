using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5b99ce-3b36-4939-9fb8-6c41a948cdc9", "AQAAAAIAAYagAAAAEPhf+ySzZuJkp5E+VgOfX6A1iDgDKL7O7OPNpG3fYC07zXbt75zO3l3tD/WNUQGEKQ==", "eb06d98c-dd7d-4590-9ed4-5c2978ebdaaf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adfd08b3-e737-4a0a-bc22-69c8c9059114", "AQAAAAIAAYagAAAAECBliBwiibb6TrRwApVb0HW1jj/oxgbKeJO7CkOwuY5SAX83nhzyYL75VBrSDtcswA==", "261fd262-5d72-4569-9d8b-7b62eb9fa7da" });
        }
    }
}
