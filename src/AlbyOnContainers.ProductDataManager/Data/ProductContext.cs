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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(i => i.Category)
            .WithMany(i => i.Products)
            .HasForeignKey(i => i.CategoryId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<Attr>()
            .HasOne(i => i.AttrType)
            .WithMany(i => i.Attrs)
            .HasForeignKey(i => i.AttrTypeId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<Attr>()
            .HasOne(i => i.Product)
            .WithMany(i => i.Attrs)
            .HasForeignKey(i => i.ProductId)
            .HasPrincipalKey(i => i.Id);

        builder.Entity<Category>()
            .HasOne(i => i.Parent)
            .WithMany(i => i.Categories)
            .HasForeignKey(i => i.ParentId)
            .IsRequired(false)
            .HasPrincipalKey(i => i.Id);

        builder
            .Entity<CategoryLevel>()
            .ToView("categories_view");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Attr> Attrs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<AttrType> AttrTypes { get; set; }
}