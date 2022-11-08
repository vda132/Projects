using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.API.ViewModels.Role;

public class CreateRoleViewModel : BaseViewModel
{
    public string Name { get; set; } = default!;
}
