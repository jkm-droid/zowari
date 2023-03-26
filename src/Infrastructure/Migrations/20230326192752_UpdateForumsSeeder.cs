using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateForumsSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("35d6c2f7-4b31-4b2a-9354-1c4d37f740bf"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("37b666df-9316-4774-8230-2b1e0f074db5"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("dc33bfc1-f3c9-4be2-8f63-9b208c6652e8"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                column: "ConcurrencyStamp",
                value: "077abf20-805c-4c6b-8699-9ac6a796e729");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                column: "ConcurrencyStamp",
                value: "12cdd92b-8b56-40f3-9773-46b5866be919");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                column: "ConcurrencyStamp",
                value: "93ed04c6-957c-4f85-8f4e-45e453c412db");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                column: "ConcurrencyStamp",
                value: "3b953f63-aecb-4576-a3b9-3bc5e0e53645");

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("2e48d11f-102d-45e0-8c93-a0b87426d0fa"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature" },
                    { new Guid("618f0db7-64b1-4c8a-8ebb-23f687be3776"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World Politics" },
                    { new Guid("627f0415-285b-4ad7-9bd7-a0f004094cab"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Software Development", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("2e48d11f-102d-45e0-8c93-a0b87426d0fa"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("618f0db7-64b1-4c8a-8ebb-23f687be3776"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("627f0415-285b-4ad7-9bd7-a0f004094cab"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                column: "ConcurrencyStamp",
                value: "fd2acc59-b442-4b2a-8318-f3ec70116dbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                column: "ConcurrencyStamp",
                value: "a1a4c3bf-967b-4d63-8b64-57bd44a5d090");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                column: "ConcurrencyStamp",
                value: "da5fdcbf-d149-4306-8032-a6c32783749e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                column: "ConcurrencyStamp",
                value: "f29e237d-58bf-4422-8693-8579dd26606e");

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("35d6c2f7-4b31-4b2a-9354-1c4d37f740bf"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello" },
                    { new Guid("37b666df-9316-4774-8230-2b1e0f074db5"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature" },
                    { new Guid("dc33bfc1-f3c9-4be2-8f63-9b208c6652e8"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics" }
                });
        }
    }
}
