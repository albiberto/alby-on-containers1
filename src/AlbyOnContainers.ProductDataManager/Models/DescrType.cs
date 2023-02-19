namespace AlbyOnContainers.ProductDataManager.Models;

public class DescrType : Entity
{
    public ICollection<DescrDetail> DescrDetails { get; set; } = new HashSet<DescrDetail>();
    public ICollection<DescrTypeCategory> DescrTypeCategories { get; set; } = new HashSet<DescrTypeCategory>();
}