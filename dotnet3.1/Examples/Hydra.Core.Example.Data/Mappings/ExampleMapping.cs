using Hydra.Core.Example.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hydra.Core.Example.Data.Mappings
{
    public class ExampleMapping : IEntityTypeConfiguration<ExampleEntity>
    {
        public void Configure(EntityTypeBuilder<ExampleEntity> builder)
        {
           builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

                //1 : N => Categories : Products
                // builder.HasMany(c => c.Products)
                //         .WithOne(p => p.Category)
                //         .HasForeignKey(p => p.CategoryId);

            builder.ToTable("ExampleEntity");
        }
    }
}