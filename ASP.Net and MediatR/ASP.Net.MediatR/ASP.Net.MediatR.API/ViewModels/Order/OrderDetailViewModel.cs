using ASP.Net.MediatR.API.ViewModels.Product;
using ASP.Net.MediatR.CRUD;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net.MediatR.API.ViewModels.Order;

public class OrderDetailViewModel : BaseViewModel
{
    [Required]
    public int OrderId { get; set; }
    [Required]
    public int Ammount { get; set; }
    public ProductViewModel Product { get; set; } = default!;
}
