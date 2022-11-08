using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.Contacts.Dto;

public class RoleDto : BaseDto<int>
{
    public string Name { get; set; } = default!;
    public IEnumerable<UserDto> Users { get; set; } = default!;
}