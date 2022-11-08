using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.DAL.Models;

public class Order : BaseModel<int>
{
    public string City { get; set; } = default!;
    public DateTime OrderDate { get; set; } 
    public Guid UserId { get; set; }
    public decimal Sum { get; set; }
    public User User { get; set; } = default!;
    public IEnumerable<OrderDetail> Details { get; set; } = default!;
}
