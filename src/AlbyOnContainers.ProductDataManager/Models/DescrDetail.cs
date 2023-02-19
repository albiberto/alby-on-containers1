namespace AlbyOnContainers.ProductDataManager.Models;

public class DescrDetail : Entity
{
    public Guid DescrTypeId { get; set; }
    public DescrType DescrType { get; set; }
}