using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.DAL.Models;

public class OrderDetail : BaseModel<int>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Ammount { get; set; }
    public Product Product { get; set; } = default!;
    public Order Order { get; set; } = default!;
}
