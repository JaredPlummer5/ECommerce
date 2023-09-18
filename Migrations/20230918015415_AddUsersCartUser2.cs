using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersCartUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                name: "IX_UsersCart_UserId",
                table: "UsersCart",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCart_AspNetUsers_UserId",
                table: "UsersCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
