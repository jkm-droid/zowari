using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddUserIdToUserCreatableTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Topics",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Messages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Likes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                defaultValue: "False",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                defaultValue: "Level 0",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Activities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64fb3971-ae1e-4ee1-88e3-f84749b1fe66"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "48732a76-85a1-4e70-bfc2-8120d7d4706f", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f6afb52-c01b-4b36-b3c9-946ab09f3334"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "84bf6c35-d8e9-4252-ab4f-29a071885939", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa3062aa-5f5d-4cce-b156-c6268148c03a"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "8bbeb29a-2e94-4ef4-90f6-900ec33ef89f", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb9b764b-6248-4fa8-94d9-f8aba057fd12"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "LastModifiedOn" },
                values: new object[] { "83391883-e2cf-4f2d-bcb1-43037eede4bc", new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "ForumLists",
                columns: new[] { "ForumId", "CreatedBy", "CreatedOn", "Description", "LastModifiedBy", "LastModifiedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("028237be-54aa-432d-8b2a-95467170fc31"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Nature" },
                    { new Guid("64b70674-1d33-49c0-a8f6-1aed5e780edb"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "World politics" },
                    { new Guid("6f56b2dd-69c4-4104-b73f-4891257a83de"), null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello world forum", null, new DateTimeOffset(new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Hello" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_UserId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserId",
                table: "Activities");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProfileUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "False");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Level 0");

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
        }
    }
}
