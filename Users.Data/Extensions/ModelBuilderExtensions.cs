using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Data.Entities;
using Users.Data.Entities.Enums;

namespace Users.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Iphone", LanguageId = "vi-VN", SeoAlias = "iphone", SeoDescription = "Điện thoại chính hãng Apple", SeoTitle = "Điện thoại chính hãng Apple" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Iphone", LanguageId = "en-US", SeoAlias = "iphone", SeoDescription = "Genuine Apple phone", SeoTitle = "Genuine Apple phone" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Samsung", LanguageId = "vi-VN", SeoAlias = "samsung", SeoDescription = "Điện thoại Samsung chính hãng", SeoTitle = "Điện thoại Samsung chính hãng" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Samsung", LanguageId = "en-US", SeoAlias = "samsung", SeoDescription = "Genuine Samsung phone", SeoTitle = "Genuine Samsung phone" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               ID = 1,
               DateCreate = DateTime.Now,
               OgPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Iphone 14 128GB",
                     LanguageId = "vi-VN",
                     SeoAlias = "iphon-14-128GB",
                     SeoDescription = "Điện thoại Iphone 14 chính hãng Apple",
                     SeoTitle = "Điện thoại Iphone 14 chính hãng Apple",
                     Details = "Điện thoại Iphone 14 chính hãng Apple",
                     Description = "Điện thoại Iphone 14 chính hãng Apple"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Iphone 14 128GB",
                        LanguageId = "en-US",
                        SeoAlias = "iphon-14-128GB",
                        SeoDescription = "Genuine Apple Iphone 14 phone",
                        SeoTitle = "Genuine Apple Iphone 14 phone",
                        Details = "Genuine Apple Iphone 14 phone",
                        Description = "Genuine Apple Iphone 14 phone"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );
            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUsers>();
            modelBuilder.Entity<AppUsers>().HasData(new AppUsers
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "ndt2212@gmail.com",
                NormalizedEmail = "katsu2212@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                LastName = "Thắng",
                FirstName = "Nguyễn Đức",
                DoB = new DateTime(22,2,22),
                Adress = "2 Lê Văn Tám"
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }

    }
}
