using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Migrations
{
    /// <inheritdoc />
    public partial class adddefalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c88058e-8872-4046-85cf-82e07497bcb7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "36cf13c3-c7c0-459a-9129-8a0794b55b17", 0, "Gaza", "824a1f9e-9836-4508-98fb-b08e75e92641", "moayad@gmail.com", false, true, false, null, null, null, "123456789", null, null, false, "e640b748-cf65-4ded-ab82-e3271b7c854a", false, "Moayadmadhoun" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36cf13c3-c7c0-459a-9129-8a0794b55b17");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c88058e-8872-4046-85cf-82e07497bcb7", 0, "Gaza", "1e4edcc7-50b7-400f-8f10-118775b70bf3", "moayad@gmail.com", false, true, false, null, null, null, "123456789", null, null, false, "d0dfd9a8-9818-41d1-a194-10502ea95ff8", false, "Moayadmadhoun" });
        }
    }
}
