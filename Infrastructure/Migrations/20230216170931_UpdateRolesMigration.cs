using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3680831c-40ab-49b3-ac95-b4fd96cc2262"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a61387a3-7379-4776-b5ab-7c76ac6ad031"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"), "4fb63c0e-8b51-4e7e-a52e-2a29fced51f1", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2853), new TimeSpan(0, 0, 0, 0, 0)), "Visitor role description", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 0, 0, 0, 0)), "Visitor", "VISITOR" },
                    { new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"), "b5a2bbfd-7a22-471f-a326-80d5884abc97", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2936), new TimeSpan(0, 0, 0, 0, 0)), "Administrator role description", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2936), new TimeSpan(0, 0, 0, 0, 0)), "Administrator", "ADMINISTRATOR" },
                    { new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"), "f6012a1f-4da9-443e-ac3b-ff1daf960fa0", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 0, 0, 0, 0)), "Basic role description", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2918), new TimeSpan(0, 0, 0, 0, 0)), "BasicUser", "BASICUSER" },
                    { new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"), "5a5989b8-bf29-4177-92fd-eda87767e410", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 0, 0, 0, 0)), "Administrator role description", null, new DateTimeOffset(new DateTime(2023, 2, 16, 17, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(2896), new TimeSpan(0, 0, 0, 0, 0)), "SuperAdministrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("1404dde0-45cc-4438-9fd8-03e0ed5d6d16"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3260), new TimeSpan(0, 3, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3293), new TimeSpan(0, 3, 0, 0, 0)), "Hello" },
                    { new Guid("620c985b-dcd8-499b-91f7-32ee5498822e"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3321), new TimeSpan(0, 3, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3322), new TimeSpan(0, 3, 0, 0, 0)), "World politics" },
                    { new Guid("f390a27d-dbd5-4254-9001-ec0848854d4d"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3337), new TimeSpan(0, 3, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 9, 30, 812, DateTimeKind.Unspecified).AddTicks(3338), new TimeSpan(0, 3, 0, 0, 0)), "Nature" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("1404dde0-45cc-4438-9fd8-03e0ed5d6d16"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("620c985b-dcd8-499b-91f7-32ee5498822e"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("f390a27d-dbd5-4254-9001-ec0848854d4d"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3680831c-40ab-49b3-ac95-b4fd96cc2262"), "7c1388df-7c2b-4cf9-87e3-3e310283abc5", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)), "Administrator role description", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 0, 0, 0, 0)), "Administrator", "ADMINISTRATOR" },
                    { new Guid("a61387a3-7379-4776-b5ab-7c76ac6ad031"), "41242bd9-e80e-476d-9831-911711df7edd", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(5927), new TimeSpan(0, 0, 0, 0, 0)), "Visitor role description", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 0, 0, 0, 0)), "Visitor", "VISITOR" }
                });
        }
    }
}
