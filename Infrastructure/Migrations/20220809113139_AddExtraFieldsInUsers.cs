using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddExtraFieldsInUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eedebddb-01da-49f6-a4a8-6307d098a8e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f021def2-6a08-457f-9611-1b972d67c5a9"));

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3680831c-40ab-49b3-ac95-b4fd96cc2262"), "7c1388df-7c2b-4cf9-87e3-3e310283abc5", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(6040), new TimeSpan(0, 0, 0, 0, 0)), "Administrator role description", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(6041), new TimeSpan(0, 0, 0, 0, 0)), "Administrator", "ADMINISTRATOR" },
                    { new Guid("a61387a3-7379-4776-b5ab-7c76ac6ad031"), "41242bd9-e80e-476d-9831-911711df7edd", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(5927), new TimeSpan(0, 0, 0, 0, 0)), "Visitor role description", null, new DateTimeOffset(new DateTime(2022, 8, 9, 11, 31, 39, 34, DateTimeKind.Unspecified).AddTicks(5928), new TimeSpan(0, 0, 0, 0, 0)), "Visitor", "VISITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3680831c-40ab-49b3-ac95-b4fd96cc2262"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a61387a3-7379-4776-b5ab-7c76ac6ad031"));

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("eedebddb-01da-49f6-a4a8-6307d098a8e2"), "c14c7f54-8414-472e-acfe-912b81d74a48", null, new DateTimeOffset(new DateTime(2022, 7, 17, 10, 25, 19, 899, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, 0, 0, 0, 0)), "Administrator role description", null, new DateTimeOffset(new DateTime(2022, 7, 17, 10, 25, 19, 899, DateTimeKind.Unspecified).AddTicks(7609), new TimeSpan(0, 0, 0, 0, 0)), "Administrator", "ADMINISTRATOR" },
                    { new Guid("f021def2-6a08-457f-9611-1b972d67c5a9"), "9b07f3fc-598f-44ab-acae-ab94b49c2479", null, new DateTimeOffset(new DateTime(2022, 7, 17, 10, 25, 19, 899, DateTimeKind.Unspecified).AddTicks(7576), new TimeSpan(0, 0, 0, 0, 0)), "Visitor role description", null, new DateTimeOffset(new DateTime(2022, 7, 17, 10, 25, 19, 899, DateTimeKind.Unspecified).AddTicks(7577), new TimeSpan(0, 0, 0, 0, 0)), "Visitor", "VISITOR" }
                });
        }
    }
}
