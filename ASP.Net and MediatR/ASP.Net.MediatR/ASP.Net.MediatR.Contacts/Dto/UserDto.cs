using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.Contacts.Dto;

public class UserDto : BaseDto<Guid>
{
    public string Name { get; set; } = default!;
    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime RegisterDate { get; set; }
    public int RoleId { get; set; }
    public string Role { get; set; } = default!;
    public IEnumerable<OrderDto> Orders { get; set; } = default!;
}