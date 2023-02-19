namespace AlbyOnContainers.ProductDataManager.Models;

public class Descr : Entity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public Guid DescrDetailId { get; set; }
    public DescrDetail DescrDetail { get; set; }
}