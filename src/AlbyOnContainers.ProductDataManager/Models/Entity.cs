namespace AlbyOnContainers.ProductDataManager.Models;

using System;
using System.ComponentModel.DataAnnotations;

public abstract class Entity :  IEquatable<Entity>
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

    public bool Equals(Entity other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}