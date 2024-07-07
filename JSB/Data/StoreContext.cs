using JSB.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JSB.Data;

public class StoreContext : DbContext
{

    public StoreContext(DbContextOptions<StoreContext> options) :base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
}
