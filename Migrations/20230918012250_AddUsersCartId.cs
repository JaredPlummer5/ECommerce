using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCartId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60e02ba-1db5-45cf-957a-fb4fe78180ec", "AQAAAAIAAYagAAAAEHtkOgkEAO9OiXmIVEwoXDgm+zpa0EHX+R59fx1tnvvo6icrQrOOXBooGYT9Tel25w==", "1ccbd3c1-09aa-4911-83f1-7503fabd03e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d6ac8f0-4975-4b71-85ec-5d7355308e0e", "AQAAAAIAAYagAAAAEG4AG7mNZQvjbpk6sRD8V8OA1sfdsW7sW6h342qwiZq5QaHt8ygGhEWug9g9t59q/g==", "42bdd835-173c-4a35-a309-8e66120f95c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1f9b63c-20a6-4b6f-a1a7-a7cb6c0ac1ea", "AQAAAAIAAYagAAAAEDvzb7aTiWZu9iTQt93V3T9MKycyI4b/9uSEPtfsEDGgubaAwg9YtGft6FKV+1svlA==", "dea0a122-17d5-44a4-8369-fe0d841b1a68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f2a488a-18d3-4b42-96f5-65d77c73a9c9", "AQAAAAIAAYagAAAAEOQiCaVUOoKB5Yxnw8b+rCYfPZj5VpHQO/vTzmO70CaZIKxHfh5C32pC4RZCpaT7Ng==", "654cf448-9a35-4a60-935d-7bef171b11e8" });
        }
    }
}
