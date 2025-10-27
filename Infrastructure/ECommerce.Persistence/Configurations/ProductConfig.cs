using ECommerce.Domain.Model.ProductModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(P => P.Brand)
              .WithMany()
              .HasForeignKey(P => P.BrandId);

            builder.HasOne(P => P.Type)
               .WithMany()
               .HasForeignKey(P => P.TypeId);

            builder.Property(P => P.Price).HasColumnType("decimal(10,3)");
        }
    }
}
