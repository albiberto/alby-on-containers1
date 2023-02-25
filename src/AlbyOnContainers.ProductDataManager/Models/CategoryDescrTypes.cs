namespace AlbyOnContainers.ProductDataManager.Models;

using Abstract;

public class CategoryDescrTypes: Auditable
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    public Guid DescrTypeId { get; set; }
    public DescrType DescrType { get; set; }
}