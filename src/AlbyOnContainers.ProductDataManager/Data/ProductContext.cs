namespace AlbyOnContainers.ProductDataManager.Data;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;

public partial class ProductContext : DbContext
{
    public ProductContext()
    {
    }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new List<IInterceptor>
        {
            new EntityInterceptor()
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .BuildProduct()
            .BuildCategory()
            .BuildDescriptions();
    }



    private static void BuildAttr(ModelBuilder modelBuilder)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Attr> Attrs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AttrType> AttrTypes { get; set; }
}