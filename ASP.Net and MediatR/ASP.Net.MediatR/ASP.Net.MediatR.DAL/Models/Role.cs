using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.DAL.Models;

public class Role : BaseModel<int>
{
    public string Name { get; set; } = default!;
    public IEnumerable<User> Users { get; set; } = default!;
}
