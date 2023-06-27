using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Data.Migrations
{
    public partial class UpdateAdressAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "Adress", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2 Lê Văn Tám", "c81db93c-cdce-4a48-a34e-4930ef445cdd", "AQAAAAEAACcQAAAAEL+PyQOf85qZZggsjPLFxOAz+bTF/mLqccFvGFb6rKvRNMk1AtRGlxwLZlAnutbE5A==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 27, 12, 15, 20, 701, DateTimeKind.Local).AddTicks(5214));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "AppUser");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "fbd5eb5c-73da-4d1b-9bd4-2d4dce89cc83");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1aed9964-081c-4928-ac69-ff3fe8014c69", "AQAAAAEAACcQAAAAEP6n+BVQZD/U/drrw7VmfH8RFSez6/EBWKhCqvwKG7QQjTrffjPo0mHztEnvw6mVdA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 27, 11, 37, 42, 633, DateTimeKind.Local).AddTicks(2611));
        }
    }
}
