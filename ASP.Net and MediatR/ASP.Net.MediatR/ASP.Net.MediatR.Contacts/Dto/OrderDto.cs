using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.Contacts.Dto;

public class OrderDto : BaseDto<int>
{
    public string City { get; set; } = default!;
    public DateTime OrderDate { get; set; } 
    public Guid UserId { get; set; }
    public UserDto User { get; set; } = default!;
    public decimal Sum { get; set; }
    public IEnumerable<OrderDetailDto> Details { get; set; } = default!;
}