using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCartUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersCart_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersCart",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersCart_UserId",
                table: "UsersCart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCart_AspNetUsers_UserId",
                table: "UsersCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCart_AspNetUsers_UserId",
                table: "UsersCart");

            migrationBuilder.DropIndex(
                name: "IX_UsersCart_UserId",
                table: "UsersCart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersCart",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "CartId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "a60e02ba-1db5-45cf-957a-fb4fe78180ec", "AQAAAAIAAYagAAAAEHtkOgkEAO9OiXmIVEwoXDgm+zpa0EHX+R59fx1tnvvo6icrQrOOXBooGYT9Tel25w==", "1ccbd3c1-09aa-4911-83f1-7503fabd03e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "CartId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "4d6ac8f0-4975-4b71-85ec-5d7355308e0e", "AQAAAAIAAYagAAAAEG4AG7mNZQvjbpk6sRD8V8OA1sfdsW7sW6h342qwiZq5QaHt8ygGhEWug9g9t59q/g==", "42bdd835-173c-4a35-a309-8e66120f95c4" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersCart_CartId",
                table: "AspNetUsers",
                column: "CartId",
                principalTable: "UsersCart",
                principalColumn: "Id");
        }
    }
}
