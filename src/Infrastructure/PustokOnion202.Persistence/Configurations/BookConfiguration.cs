using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PustokOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Price).IsRequired().HasColumnType("decimal(6,2)");
            builder.Property(b => b.Discount).IsRequired().HasColumnType("decimal(6,2)");
        }
    }
}
