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

        modelBuilder.Entity<Product>()
            .HasOne(i => i.Category)
            .WithMany(i => i.Products)
            .HasForeignKey(i => i.CategoryId)
            .HasPrincipalKey(i => i.Id);

        modelBuilder.Entity<Attr>()
            .HasOne(i => i.AttrType)
            .WithMany(i => i.Attrs)
            .HasForeignKey(i => i.AttrTypeId)
            .HasPrincipalKey(i => i.Id);

        modelBuilder.Entity<Attr>()
            .HasOne(i => i.Product)
            .WithMany(i => i.Attrs)
            .HasForeignKey(i => i.ProductId)
            .HasPrincipalKey(i => i.Id);

        modelBuilder.Entity<Category>()
            .HasOne(i => i.Parent)
            .WithMany(i => i.Categories)
            .HasForeignKey(i => i.ParentId)
            .IsRequired(false)
            .HasPrincipalKey(i => i.Id);

        modelBuilder.Entity<DescrTypeCategory>().HasKey(dc => dc.Id);

        modelBuilder.Entity<DescrTypeCategory>()
            .HasOne(sc => sc.Category)
            .WithMany(s => s.DescrTypeCategories)
            .HasForeignKey(sc => sc.CategoryId);
        
        modelBuilder.Entity<DescrTypeCategory>()
            .HasOne(sc => sc.DescrType)
            .WithMany(s => s.DescrTypeCategories)
            .HasForeignKey(sc => sc.DescrTypeId);

        modelBuilder.Entity<DescrDetail>()
            .HasOne(dd => dd.DescrType)
            .WithMany(dt => dt.DescrDetails)
            .HasForeignKey(dd => dd.DescrTypeId);
        
        modelBuilder.Entity<Descr>()
            .HasOne(sc => sc.Product)
            .WithMany(s => s.Descrs)
            .HasForeignKey(sc => sc.ProductId);
        
        modelBuilder.Entity<Descr>()
            .HasOne(sc => sc.DescrDetail)
            .WithMany(s => s.Descrs)
            .HasForeignKey(sc => sc.DescrDetailId);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Attr> Attrs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AttrType> AttrTypes { get; set; }
}