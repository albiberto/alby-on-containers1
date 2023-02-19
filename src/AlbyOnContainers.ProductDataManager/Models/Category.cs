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

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    public ICollection<DescrTypeCategory> DescrTypeCategories { get; set; } = new HashSet<DescrTypeCategory>();
}