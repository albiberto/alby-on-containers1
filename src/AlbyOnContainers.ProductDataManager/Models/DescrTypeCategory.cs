namespace AlbyOnContainers.ProductDataManager.Models;

public class DescrTypeCategory: Entity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    
    public Guid DescrTypeId { get; set; }
    public DescrType DescrType { get; set; }
}