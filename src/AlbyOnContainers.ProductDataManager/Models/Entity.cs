namespace AlbyOnContainers.ProductDataManager.Models;

using System;
using System.ComponentModel.DataAnnotations;

public abstract class Entity
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    [ConcurrencyCheck]
    public string Name { get; set; }
    
    [Required]
    [ConcurrencyCheck]
    public string Description { get; set; }

    [Required]
    [ConcurrencyCheck]
    public DateTime Created { get; set; }
    
    [Required]
    [ConcurrencyCheck]
    public string CreatedBy { get; set; }

    [Required]
    [ConcurrencyCheck]
    public DateTime LastModified  { get; set; }
    
    [Required]
    [ConcurrencyCheck]
    public string LastModifiedBy  { get; set; }
}