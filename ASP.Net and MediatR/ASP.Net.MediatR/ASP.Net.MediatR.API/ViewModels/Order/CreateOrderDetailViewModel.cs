using ASP.Net.MediatR.CRUD;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net.MediatR.API.ViewModels.Order
{
    public class CreateOrderDetailViewModel : BaseViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Ammount { get; set; }
    }
}
