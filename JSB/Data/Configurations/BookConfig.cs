

namespace JSB.Data.Configurations;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b=>b.BookId);
        builder.Property(b=>b.Name).IsRequired();
        builder.ToTable(b => b.HasCheckConstraint("CK_price_non-negative", "price > 0"));
        builder.ToTable(b => b.HasCheckConstraint("CK_Stock_non-negative", "Stock > 0"));
    }
}
