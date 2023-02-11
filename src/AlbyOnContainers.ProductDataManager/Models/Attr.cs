namespace AlbyOnContainers.ProductDataManager.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Attr : Entity
{
    [ConcurrencyCheck]
    public required Guid ProductId { get; set; }

    [ConcurrencyCheck]
    public required Guid AttrTypeId { get; set; }
        
    public AttrType? AttrType { get; set; }

    public Product? Product { get; set; }
}