﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RemoveNullablesFromUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("028237be-54aa-432d-8b2a-95467170fc31"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("64b70674-1d33-49c0-a8f6-1aed5e780edb"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("6f56b2dd-69c4-4104-b73f-4891257a83de"));

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                column: "ConcurrencyStamp",
                value: "48732a76-85a1-4e70-bfc2-8120d7d4706f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                column: "ConcurrencyStamp",
                value: "84bf6c35-d8e9-4252-ab4f-29a071885939");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                column: "ConcurrencyStamp",
                value: "8bbeb29a-2e94-4ef4-90f6-900ec33ef89f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                column: "ConcurrencyStamp",
                value: "83391883-e2cf-4f2d-bcb1-43037eede4bc");

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("028237be-54aa-432d-8b2a-95467170fc31"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature" },
                    { new Guid("64b70674-1d33-49c0-a8f6-1aed5e780edb"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics" },
                    { new Guid("6f56b2dd-69c4-4104-b73f-4891257a83de"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello" }
                });
        }
    }
}
