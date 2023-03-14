using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateBookmarksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Messages_MessageId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Topics_TopicId",
                table: "BookMarks");

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("ab25ffd5-426c-46a4-9de0-461d4307c63f"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("c3ea7f05-9a77-4c73-992f-a98da7be742f"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("dea2373f-ea10-417f-81b8-55267180e0af"));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Topics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Topics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Topics",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Tag",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ForumLists",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "NiceName",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Iso3",
                table: "Countries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Iso",
                table: "Countries",
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

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Comments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "BookMarks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "BookMarks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityBody",
                table: "Activities",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "2901169b-59eb-4ff3-89a2-dfaa25941fdb", new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3425), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "15006bad-7152-4dc6-bf24-7e1d3cfd2976", new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3512), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "2fedb932-10a8-4372-a02f-9c28e1a5d320", new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3491), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3492), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "5d803063-8db2-4623-b8e1-2971ed0fcb0b", new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 14, 18, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3463), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("25c6e48c-b635-4291-b7dd-b679390dd437"), null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(4078), new TimeSpan(0, 3, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(4079), new TimeSpan(0, 3, 0, 0, 0)), "Nature" },
                    { new Guid("9e1ac412-8b1b-4cdd-8e80-d9356523f673"), null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(3985), new TimeSpan(0, 3, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(4034), new TimeSpan(0, 3, 0, 0, 0)), "Hello" },
                    { new Guid("e922cb47-1910-4870-8567-d4ab92f89d40"), null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(4060), new TimeSpan(0, 3, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 3, 14, 21, 5, 18, 291, DateTimeKind.Unspecified).AddTicks(4062), new TimeSpan(0, 3, 0, 0, 0)), "World politics" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Messages_MessageId",
                table: "BookMarks",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Topics_TopicId",
                table: "BookMarks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Messages_MessageId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Topics_TopicId",
                table: "BookMarks");

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("25c6e48c-b635-4291-b7dd-b679390dd437"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("9e1ac412-8b1b-4cdd-8e80-d9356523f673"));

            migrationBuilder.DeleteData(
                table: "ForumLists",
                keyColumn: "ForumId",
                keyValue: new Guid("e922cb47-1910-4870-8567-d4ab92f89d40"));

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Tag",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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
                name: "Author",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ForumLists",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NiceName",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iso3",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iso",
                table: "Countries",
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

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TopicId",
                table: "BookMarks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "BookMarks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActivityBody",
                table: "Activities",
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
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "5d331868-9447-422f-824c-64bada4ac955", new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7836), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7837), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "f8c97c77-a4eb-4081-a0d9-060229f17017", new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7920), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "09a32aab-0cd3-402f-a3ce-0d324063468c", new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7901), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7902), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "7854ed9e-7b1a-4e28-84ce-670da03f3ef6", new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7883), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 2, 16, 17, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(7884), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("ab25ffd5-426c-46a4-9de0-461d4307c63f"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 3, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8378), new TimeSpan(0, 3, 0, 0, 0)), "World politics" },
                    { new Guid("c3ea7f05-9a77-4c73-992f-a98da7be742f"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, 3, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8355), new TimeSpan(0, 3, 0, 0, 0)), "Hello" },
                    { new Guid("dea2373f-ea10-417f-81b8-55267180e0af"), null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8393), new TimeSpan(0, 3, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 2, 16, 20, 26, 43, 815, DateTimeKind.Unspecified).AddTicks(8394), new TimeSpan(0, 3, 0, 0, 0)), "Nature" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Messages_MessageId",
                table: "BookMarks",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Topics_TopicId",
                table: "BookMarks",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId");
        }
    }
}
