namespace AlbyOnContainers.ProductDataManager.Models;

using Abstract;

public class DescrType : Entity
{
    public ICollection<DescrValue> DescrValues { get; set; } = new HashSet<DescrValue>();
    public ICollection<CategoryDescrTypes> CategoryDescrTypes { get; set; } = new HashSet<CategoryDescrTypes>();
}