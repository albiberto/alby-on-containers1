namespace AlbyOnContainers.ProductDataManager.Models;

using Abstract;

public class CategoryAttrTypes : Auditable
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    public Guid AttrTypeId { get; set; }
    public AttrType AttrType { get; set; }
}