using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_UsersCartId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "UsersCart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersCart",
                table: "UsersCart",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersCart_CartId",
                table: "AspNetUsers",
                column: "CartId",
                principalTable: "UsersCart",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UsersCart_UsersCartId",
                table: "Products",
                column: "UsersCartId",
                principalTable: "UsersCart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersCart_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UsersCart_UsersCartId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersCart",
                table: "UsersCart");

            migrationBuilder.RenameTable(
                name: "UsersCart",
                newName: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8de14c9-bfef-4a6b-a448-db2fe08a15c0", "AQAAAAIAAYagAAAAEMxWRRqJk5vGI8mtNpzXQ5LGdzfkJ5+7wwePxMY7GuhQ6f+BDekGLft3ta7wI6+lDA==", "ae016dc5-91ef-4f3b-bb50-2442ab9c5d43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d8db0b3-4e03-44a8-baf5-0c202cd01ce3", "AQAAAAIAAYagAAAAELoCqwVmEJd0WpLTPI2ESgQUahTF+w60rcYqaAs/d5GrLOk+P+dNBBQVRUFkcXWmXQ==", "b9e95e71-a105-41dd-bd65-5f9d770990dd" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Carts_CartId",
                table: "AspNetUsers",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Carts_UsersCartId",
                table: "Products",
                column: "UsersCartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }
    }
}
