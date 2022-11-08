using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.Contacts.Dto;

public class ProductDto : BaseDto<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Article { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime CreationDate { get; set; }
}