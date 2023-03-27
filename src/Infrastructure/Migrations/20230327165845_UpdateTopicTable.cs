using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateTopicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Topics",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                column: "ConcurrencyStamp",
                value: "88ceb082-ff88-47c2-ab7d-d1ce7186b704");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                column: "ConcurrencyStamp",
                value: "aa2ccca8-78fd-43b4-bd32-755284d33518");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                column: "ConcurrencyStamp",
                value: "3d0099ee-1472-49be-889c-af6787552ed9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                column: "ConcurrencyStamp",
                value: "968601e9-4517-4d72-a7f3-ecdf97004c9a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Topics");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Comments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
        }
    }
}
