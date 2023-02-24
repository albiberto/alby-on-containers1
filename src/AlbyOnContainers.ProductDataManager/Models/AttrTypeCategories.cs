namespace AlbyOnContainers.ProductDataManager.Models;

public class AttrTypeCategories : Entity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    public Guid AttrTypeId { get; set; }
    public AttrType AttrType { get; set; }
}