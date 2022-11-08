using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.Contacts.Dto;

public class OrderDetailDto : BaseDto<int>
{
    public int Amount { get; set; } 
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public ProductDto Product { get; set; } = default!;
}