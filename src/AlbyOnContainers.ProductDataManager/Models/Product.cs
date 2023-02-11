namespace AlbyOnContainers.ProductDataManager.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Product : Entity
{
    [ConcurrencyCheck]
    public required Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public ICollection<Attr>? Attrs { get; set; } = new HashSet<Attr>();
}