using ASP.Net.MediatR.CRUD;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net.MediatR.API.ViewModels.Product;

public class CreateProductViewModel : BaseViewModel
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    [StringLength(60)]
    public string Description { get; set; } = default!;
    [Required]
    public string Article { get; set; } = default!;
    [Required]
    [Range(100, (double)decimal.MaxValue)]
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
}
