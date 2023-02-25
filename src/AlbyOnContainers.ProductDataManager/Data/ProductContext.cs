namespace AlbyOnContainers.ProductDataManager.Data;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using Models.Abstract;

public partial class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CategoryAttrTypes> CategoryAttrTypes { get; set; }
    public DbSet<CategoryDescrTypes> CategoryDescrTypes { get; set; }
    
    public DbSet<AttrType> AttrTypes { get; set; }
    public DbSet<Attr> Attrs { get; set; }

    public DbSet<DescrType> DescrTypes { get; set; }
    public DbSet<DescrValue> DescrValues { get; set; }
    public DbSet<Descr> Descrs { get; set; }
    
    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new List<IInterceptor>
        {
            new AuditableInterceptor()
        });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Entity>()
            .HasKey(e => e.Id);

        modelBuilder
            .BuildProduct()
            .BuildCategory()
            .BuildAttributes()
            .BuildDescriptions();
    }
}