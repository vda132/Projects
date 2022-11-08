using ASP.Net.MediatR.CRUD;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net.MediatR.API.ViewModels.Order;

public class CreateOrderViewModel : BaseViewModel
{
    [Required]
    public string City { get; set; } = default!;
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public Guid UserId { get; set; }
}
