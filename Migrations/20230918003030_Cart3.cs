using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class Cart3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UsersCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "CartId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "a8de14c9-bfef-4a6b-a448-db2fe08a15c0", "AQAAAAIAAYagAAAAEMxWRRqJk5vGI8mtNpzXQ5LGdzfkJ5+7wwePxMY7GuhQ6f+BDekGLft3ta7wI6+lDA==", "ae016dc5-91ef-4f3b-bb50-2442ab9c5d43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "CartId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "4d8db0b3-4e03-44a8-baf5-0c202cd01ce3", "AQAAAAIAAYagAAAAELoCqwVmEJd0WpLTPI2ESgQUahTF+w60rcYqaAs/d5GrLOk+P+dNBBQVRUFkcXWmXQ==", "b9e95e71-a105-41dd-bd65-5f9d770990dd" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsersCartId",
                table: "Products",
                column: "UsersCartId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers",
                column: "CartId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Carts_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Carts_UsersCartId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsersCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

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
                values: new object[] { "e1dc83e7-ecd5-461a-8860-f9e14fd79ebc", "AQAAAAIAAYagAAAAEPIyBBA3cR1ALBeHn45Phoe7MP3R7YSoVb5HwI+KoPXoWAfFyOvkZZzECqVYwNramw==", "e7853883-5eee-4477-a93a-de5648be5276" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3642d06-e4ca-430c-a31c-9af5b85d3a97", "AQAAAAIAAYagAAAAEH91nZns38Gp6nnaw+p0d1asG4nKDqQIrLiC6Oz6qWbSC7LfmF/aeibfcw3nkRMRsA==", "0b14074c-4bc9-4f9b-b329-e386f0de4376" });

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
    }
}
