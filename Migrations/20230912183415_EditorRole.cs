using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class EditorRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1006,
                column: "ClaimValue",
                value: "create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1007,
                column: "ClaimValue",
                value: "update");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1008, "permissions", "delete", "admin" },
                    { 1009, "permissions", "read", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "editor", "00000000-0000-0000-0000-000000000000", "Editor", "EDITOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4403b35f-b7e6-4f12-83f5-cb575d2d1d66", "AQAAAAIAAYagAAAAEMFElxKFnZaBf7T9n4tObiRkM6R/ez0/2iUtZ3OSZI3F8P/Xx6Ds4OW/QzDhzcr3/A==", "e341b348-e226-4680-949c-d6abd299def2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Editor-id", 0, "4f387124-95cc-4260-9153-16db114317a9", "editor@example.com", false, false, null, "editor@example.com", "EDITOR", "Password123!", "AQAAAAIAAYagAAAAEEyia8DvEN0EtRu36hjy4WjuqqxIVjK9NfZheAdKtOozHFTk46bc6kGkdAw1OAD/4Q==", null, false, "e48b8709-d3ed-481d-8a39-6a861c8e8b67", false, "Editor" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1010, "permissions", "create", "editor" },
                    { 1011, "permissions", "update", "editor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Editor", "Editor-id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Editor", "Editor-id" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "editor");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Editor-id");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1006,
                column: "ClaimValue",
                value: "delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1007,
                column: "ClaimValue",
                value: "read");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1004, "permissions", "create", "admin" },
                    { 1005, "permissions", "update", "admin" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5b99ce-3b36-4939-9fb8-6c41a948cdc9", "AQAAAAIAAYagAAAAEPhf+ySzZuJkp5E+VgOfX6A1iDgDKL7O7OPNpG3fYC07zXbt75zO3l3tD/WNUQGEKQ==", "eb06d98c-dd7d-4590-9ed4-5c2978ebdaaf" });
        }
    }
}
