using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementSystem.Domain.Migrations
{
    public partial class adminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ddcd14c6-d548-44b5-892c-719afc2690b8", "Admin", "ADMIN" },
                    { 2, "3fbf2ab1-dc7e-4db1-893a-28e0edc41432", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5d68c4eb-10ec-4c6f-9d8b-5856d963653a", "usermanagementadmin@gmail.com", false, "Admin", "Admin", false, null, "USERMANAGEMENTADMIN@GMAIL.COM", "USERMANAGEMENTADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPC3IdCxYE55MTQq6heXcNYtJ93vwBB95vh/NaLDgEg1JQfKe6m6PdBxkFt7vJ3IUQ==", null, false, null, false, "usermanagementadmin@gmail.com" },
                    { 2, 0, "5e622a1f-987d-47e0-a140-b90442e289a0", "usermanagementsuperadmin@gmail.com", false, "SuperAdmin", "SuperAdmin", false, null, "USERMANAGEMENTSUPERADMIN@GMAIL.COM", "USERMANAGEMENTSUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHc3pVBSJTuylN52kCMJNXrtcualtpQqbTpyHZNamDT515hjyeVqrDq5KuD79yjwWg==", null, false, null, false, "usermanagementsuperadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 1, 1, "UserRole" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { 2, 2, "UserRole" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");
        }
    }
}
