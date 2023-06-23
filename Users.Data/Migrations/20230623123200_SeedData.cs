using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Users.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEOAlias",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 19, 32, 0, 178, DateTimeKind.Local).AddTicks(4278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 23, 18, 22, 26, 94, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of eShopSolution" },
                    { "HomeKeyword", "This is keyword of eShopSolution" },
                    { "HomeDescription", "This is description of eShopSolution" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "IsDefault", "Name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "DateCreate", "OgPrice", "Price" },
                values: new object[] { 1, new DateTime(2023, 6, 23, 19, 32, 0, 188, DateTimeKind.Local).AddTicks(5304), 100000m, 200000m });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "Id", "CategoryId", "LanguageId", "Name", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Iphone", "iphone", "Điện thoại chính hãng Apple", "Điện thoại chính hãng Apple" },
                    { 3, 2, "vi-VN", "Samsung", "samsung", "Điện thoại Samsung chính hãng", "Điện thoại Samsung chính hãng" },
                    { 2, 1, "en-US", "Iphone", "iphone", "Genuine Apple phone", "Genuine Apple phone" },
                    { 4, 2, "en-US", "Samsung", "samsung", "Genuine Samsung phone", "Genuine Samsung phone" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "Id", "Description", "Details", "LanguageId", "Name", "ProductId", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, "Điện thoại Iphone 14 chính hãng Apple", "Điện thoại Iphone 14 chính hãng Apple", "vi-VN", "Iphone 14 128GB", 1, "iphon-14-128GB", "Điện thoại Iphone 14 chính hãng Apple", "Điện thoại Iphone 14 chính hãng Apple" },
                    { 2, "Samsung Galaxy S22 Ultra phone with a shocking discount", "Samsung Galaxy S22 Ultra phone with a shocking discount", "en-US", "Samsung Galaxy S22 Ultra", 1, "samsung-galaxy-s22-ultra", "Samsung Galaxy S22 Ultra phone with a shocking discount", "Samsung Galaxy S22 Ultra phone with a shocking discount" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDescription");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "SEOAlias",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 23, 18, 22, 26, 94, DateTimeKind.Local).AddTicks(703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 23, 19, 32, 0, 178, DateTimeKind.Local).AddTicks(4278));
        }
    }
}
