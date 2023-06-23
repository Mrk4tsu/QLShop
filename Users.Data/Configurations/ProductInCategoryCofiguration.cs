using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Data.Entities;

namespace Users.Data.Configurations
{
    public class ProductInCategoryCofiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(t => new
            {
                t.Category,
                t.CategoryId
            });
            builder.ToTable("ProductInCategories");

            builder.HasOne(t => t.Product).WithMany(p => p.ProductInCategories).HasForeignKey(p => p.ProductId);
            builder.HasOne(t => t.Category).WithMany(p => p.ProductInCategories).HasForeignKey(p => p.CategoryId);
        }
    }
}
