using JSB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSB.Data.Configurations;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c=>c.CategoryId);
        builder.Property(c=>c.Description).IsRequired();
        builder.Property(c=>c.Name).IsRequired();
    }
}
