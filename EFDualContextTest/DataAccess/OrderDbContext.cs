using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.DataAccess;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<History> Histories { get; set; }
   
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //v1
        /*modelBuilder.Entity<Person>()
            .HasMany(x=>x.Orders)
            .WithOne(o=>o.Owner)
            .OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey("OwnerId")
            .Metadata.DependentToPrincipal?.SetPropertyAccessMode(PropertyAccessMode.Field);*/
        
        //v2
        modelBuilder.Entity<Person>()
            .HasMany<Order>(x => x.Orders)
            .WithOne(x=> x.Owner)
            .IsRequired(false);

        modelBuilder.Entity<Person>()
            .OwnsOne(x => x.Address, builder =>
            {
                builder.Property(o => o.City).HasColumnName("City").IsRequired(false);
                builder.Property(o => o.Street).HasColumnName("Street").IsRequired(false);
            });

        /*
        modelBuilder.Entity<Seller>().Property(x=>x.ProductId).HasColumnName("ProductId");
        modelBuilder.Entity<Product>().HasMany<Seller>()
            .WithOne()
            .HasForeignKey(x => x.ProductId);
            */

        
        /*modelBuilder.Entity<Person>()
            .HasMany<History>(x => x.Histories)
            .WithOne()
            //.OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey("PersonId")
            .IsRequired(false);*/
    }
}