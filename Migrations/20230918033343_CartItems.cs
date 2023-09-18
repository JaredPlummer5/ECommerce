using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class CartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UsersCart_UsersCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UsersCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UsersCartId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UsersCartId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_UsersCart_UsersCartId",
                        column: x => x.UsersCartId,
                        principalTable: "UsersCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "221535af-1ad0-4e76-b4c8-d84917d9222a", "AQAAAAIAAYagAAAAEP+wnCfqBp5e2GiBCM53jHzK0fIpubT+V+puegJ+7ZhmbpB+Ya/Jv5JMzW0uT/3wlQ==", "984c5bb3-9f93-4bed-9e12-10064d44e172" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cf4058a-e1c5-49c0-96de-c8ae17e7c82a", "AQAAAAIAAYagAAAAEHS+/Bl7fEFbGNQ/I7mGTRI+KgNnKP6xykwmmh+5wj1j6oHVJHkTfpUo6uGhzdyHCQ==", "a59dd478-f754-4429-a701-2848f6e4e6cb" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_UsersCartId",
                table: "CartItem",
                column: "UsersCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.AddColumn<int>(
                name: "UsersCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "110924a7-25e9-49cc-bc72-f58a13a215d6", "AQAAAAIAAYagAAAAEMbZIh8Bi9961kTUJN6MstCgGL9fT4hwXOQGYFosJnNnml/yfawOceHvMOucHFwtQw==", "6c9db052-ba99-4d2a-aab7-49837535fe31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "570cc06c-9d96-4315-97d8-b53e52897908", "AQAAAAIAAYagAAAAEIEdQE7F6SBbUMK5kXpsm8CmRoAZ/RqrVhM7Ew0Ni/igNNkuO6fWv0iZQCbaCo9rrw==", "2f688332-8566-4b86-b40f-7c32a4c066f4" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UsersCartId",
                table: "Products",
                column: "UsersCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UsersCart_UsersCartId",
                table: "Products",
                column: "UsersCartId",
                principalTable: "UsersCart",
                principalColumn: "Id");
        }
    }
}
