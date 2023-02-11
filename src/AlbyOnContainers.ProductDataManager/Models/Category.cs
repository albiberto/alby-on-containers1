namespace AlbyOnContainers.ProductDataManager.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Category : Entity
{
    [ConcurrencyCheck]
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }

    public ICollection<Product>? Products { get; set; } = new HashSet<Product>();
    public ICollection<Category>? Categories { get; set; } = new HashSet<Category>();
}

[Keyless]
public class CategoryLevel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int Level { get; set; }
    public Guid? ParentId { get; set; }
    public string? ParentName { get; set; }

    public Category ToCategory() => new()
    {
        Id = Id,
        Name = Name,
        ParentId = ParentId,
        Description = Description
    };
}