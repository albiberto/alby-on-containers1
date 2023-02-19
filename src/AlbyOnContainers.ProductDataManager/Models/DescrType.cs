namespace AlbyOnContainers.ProductDataManager.Models;

public class DescrType : Entity
{
    public ICollection<DescrTypeCategory> DescrTypeCategories { get; set; } = new HashSet<DescrTypeCategory>();
}