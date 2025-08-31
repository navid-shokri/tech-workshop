using EFDualContextTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDualContextTest.DataAccess;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<History> Histories { get; set; }
   
    public DbSet<Product> Products { get; set; }
    public DbSet<Seller> Sellers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //v1
        modelBuilder.Entity<Author>().HasQueryFilter(x=>!x.IsDeleted).HasMany(x => x.Books).WithMany(b=>b.Authors);
        modelBuilder.Entity<Book>().HasQueryFilter(x=>!x.IsDeleted).HasMany(x => x.Authors).WithMany(a=>a.Books);
        
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



        modelBuilder.Entity<Seller>().HasMany<Product>()
            .WithOne();

        modelBuilder.Entity<Product>().ToTable("ann_dar_product");


        /*modelBuilder.Entity<Person>()
            .HasMany<History>(x => x.Histories)
            .WithOne()
            //.OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey("PersonId")
            .IsRequired(false);*/
    }
}