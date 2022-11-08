using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.DAL.Models;

public class User : BaseModel<Guid>
{
    public string Name { get; set; } = default!;
    public string Login { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime RegisterDate { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;
    public IEnumerable<Order> Orders { get; set; } = default!;
}
