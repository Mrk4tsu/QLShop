using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Data.Migrations
{
    public partial class PushDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d7b11f11-716e-4c74-9fc4-a161aa266509");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "358ef0b4-2931-4956-8fa7-06e2e36eb26e", "AQAAAAEAACcQAAAAEANoag0Qv8nGqIWCM6gF6599cyPxgpQsYN/QNb0i8HjLkCCt3pHTpcUV9VoJnBeasA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 30, 23, 27, 46, 87, DateTimeKind.Local).AddTicks(7099));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "04964321-7791-4188-aefb-caea97d2fb83");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c81db93c-cdce-4a48-a34e-4930ef445cdd", "AQAAAAEAACcQAAAAEL+PyQOf85qZZggsjPLFxOAz+bTF/mLqccFvGFb6rKvRNMk1AtRGlxwLZlAnutbE5A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 27, 12, 15, 20, 701, DateTimeKind.Local).AddTicks(5214));
        }
    }
}
