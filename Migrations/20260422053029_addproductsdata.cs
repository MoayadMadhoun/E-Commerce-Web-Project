using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyStore.Migrations
{
    /// <inheritdoc />
    public partial class addproductsdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41152caf-fcfe-499e-aeed-a987f22de917");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39bfc5c0-6b42-4198-9c99-a857b83cd2f2", 0, "Gaza", "36b3abbc-5b8b-41fd-87f8-522f6ca9149b", "AppUser", null, false, true, false, null, null, null, "12345678", null, null, false, "a5c222b7-8243-41ab-bee4-c98736d6e983", false, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImageUrl", "IsDeleted", "Name", "Price", "StockQuantity", "LastUpdate" },
                values: new object[,]
                {
                    { 1, 4, "https://picsum.photos/seed/mouse/400/300", false, "Wireless Mouse", 25.5, 50, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, "https://picsum.photos/seed/keyboard/400/300", false, "Mechanical Keyboard", 75.0, 30, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 7, "https://picsum.photos/seed/watch/400/300", false, "Smart Watch", 120.0, 20, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, "https://picsum.photos/seed/headphones/400/300", false, "Bluetooth Headphones", 60.0, 40, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, "https://picsum.photos/seed/charger/400/300", false, "USB-C Charger", 18.0, 100, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 5, "https://picsum.photos/seed/controller/400/300", false, "Gaming Controller", 55.0, 35, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 6, "https://picsum.photos/seed/chair/400/300", false, "Office Chair", 150.0, 10, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, "https://picsum.photos/seed/cooling/400/300", false, "Laptop Cooling Pad", 30.0, 45, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 15, "https://picsum.photos/seed/lens/400/300", false, "Camera Lens", 220.0, 8, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, "https://picsum.photos/seed/remote/400/300", false, "TV Remote", 15.0, 60, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 8, "https://picsum.photos/seed/blender/400/300", false, "Kitchen Blender", 95.0, 12, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 9, "https://picsum.photos/seed/dumbbells/400/300", false, "Dumbbells Set", 40.0, 25, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 12, "https://picsum.photos/seed/carholder/400/300", false, "Car Phone Holder", 12.0, 70, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 16, "https://picsum.photos/seed/toycar/400/300", false, "Toy Car", 20.0, 80, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39bfc5c0-6b42-4198-9c99-a857b83cd2f2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41152caf-fcfe-499e-aeed-a987f22de917", 0, "Gaza", "f581bef9-f095-4664-bbcc-334e56a8d16f", "AppUser", null, false, true, false, null, null, null, "12345678", null, null, false, "4d76c6bc-f6f7-4117-88e4-a5fad586d641", false, null });
        }
    }
}
