namespace AlbyOnContainers.ProductDataManager.Models;

using System.Collections.Generic;

public class AttrType : Entity
{
    public ICollection<Attr>? Attrs { get; set; } = new HashSet<Attr>();
}