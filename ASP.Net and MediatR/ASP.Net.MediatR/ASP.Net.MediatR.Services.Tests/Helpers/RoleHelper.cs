using ASP.Net.MediatR.Contacts.Dto;

namespace ASP.Net.MediatR.Services.Tests.Helpers;

public class RoleHelper : BaseHelper<int>
{
    public override IEnumerable<int> CreateIds() =>
        Enumerable.Range(1, 3).ToList();

    public IEnumerable<RoleDto> CreateRoles() =>
        Enumerable.Range(1, 3).Select(x => new RoleDto()
        {
            Id = x,
            Name = "Test Role"
        }).ToList();
}
