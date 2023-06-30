using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Data.Migrations
{
    public partial class UpdateSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 36, 51, 742, DateTimeKind.Local).AddTicks(7515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 32, 0, 178, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Details", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Genuine Apple Iphone 14 phone", "Genuine Apple Iphone 14 phone", "Iphone 14 128GB", "iphon-14-128GB", "Genuine Apple Iphone 14 phone", "Genuine Apple Iphone 14 phone" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 23, 19, 36, 51, 752, DateTimeKind.Local).AddTicks(244));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 32, 0, 178, DateTimeKind.Local).AddTicks(4278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 36, 51, 742, DateTimeKind.Local).AddTicks(7515));

            migrationBuilder.UpdateData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Details", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[] { "Samsung Galaxy S22 Ultra phone with a shocking discount", "Samsung Galaxy S22 Ultra phone with a shocking discount", "Samsung Galaxy S22 Ultra", "samsung-galaxy-s22-ultra", "Samsung Galaxy S22 Ultra phone with a shocking discount", "Samsung Galaxy S22 Ultra phone with a shocking discount" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2023, 6, 23, 19, 32, 0, 188, DateTimeKind.Local).AddTicks(5304));
        }
    }
}
