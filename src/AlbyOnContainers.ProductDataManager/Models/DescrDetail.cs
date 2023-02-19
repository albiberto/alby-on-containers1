namespace AlbyOnContainers.ProductDataManager.Models;

public class DescrDetail : Entity
{
    public Guid DescrTypeId { get; set; }
    public DescrType DescrType { get; set; }
    
    public ICollection<Descr> Descrs { get; set; } = new HashSet<Descr>();
}