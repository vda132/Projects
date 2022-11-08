using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.API.ViewModels.Role;

public class RoleViewModel : BaseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
