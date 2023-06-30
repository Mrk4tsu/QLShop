using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Data.Migrations
{
    public partial class EditSomeone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppUser",
                newName: "LastName");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AppUser",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "178b8d06-a6dc-4c62-9ebf-d83924271e74");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8400e17-fdf4-44a0-8181-7ad6fe945bcc", "AQAAAAEAACcQAAAAEBdwGZIrDHM04iQUsbHz8e2+QGfVYBiRQMR8CCooMWDHAv7xpnH7emNFcCpV50nNtg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 25, 10, 59, 8, 552, DateTimeKind.Local).AddTicks(1907));
        }
    }
}
