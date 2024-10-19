using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTJobMatch.Migrations
{
    public partial class UserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "role1", "59401cc8-260d-475b-b2ad-13f95bb8eaa6", "Employer", "EMPLOYER" },
                    { "role2", "6563545f-55ad-4e01-a23b-9039c9d45d7b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user1", 0, "6c094b03-b060-4f4c-bb2c-6bc3ff086947", "emp@gmail.com", true, false, null, "EMP0@GMAIL.COM", "EMP0@GMAIL.COM", "AQAAAAEAACcQAAAAECAUXJecM8TV0Dt77qX9V1oZRPzgZL6RcLDzts9eSWqGi7FohF0iBYhd0s5M6wwUfQ==", null, false, "359845cd-a5b9-491c-9fbb-14d1fd852af2", false, "emp@gmail.com" },
                    { "user2", 0, "8f2707a1-0607-469b-a9e3-6e3a7bef9331", "user@gmail.com", true, false, null, "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAEAACcQAAAAEEWksdt+mCsHRGNnIO5h5TQ0AfypHNa8/0JmySliluSY4ExnnhYWJN9lotkIE+dC9Q==", null, false, "5595cf37-eebf-4e92-a7a8-6676f72028e1", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user1", "role1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "user2", "role2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user1", "role1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "user2", "role2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "role2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user2");
        }
    }
}
