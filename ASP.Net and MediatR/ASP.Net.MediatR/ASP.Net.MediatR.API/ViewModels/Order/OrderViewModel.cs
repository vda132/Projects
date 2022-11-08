using ASP.Net.MediatR.API.ViewModels.User;
using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.API.ViewModels.Order;

public class OrderViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string City { get; set; } = default!;
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public UserViewModel User { get; set; } = default!;
    public decimal Sum { get; set; }
    public IEnumerable<OrderDetailViewModel> Details { get; set; } = default!;
}
