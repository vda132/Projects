using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.DAL.Models;

public class Product : BaseModel<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Article { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
    public IEnumerable<OrderDetail> Details { get; set; } = default!;
}
