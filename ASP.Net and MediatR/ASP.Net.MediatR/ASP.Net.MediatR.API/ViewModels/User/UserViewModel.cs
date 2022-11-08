using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.CRUD;

namespace ASP.Net.MediatR.API.ViewModels.User
{
    public class UserViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Login { get; set; } = default!;
        public DateTime RegisterDate { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; } = default!;
        public IEnumerable<OrderDto> Orders { get; set; } = default!;
    }
}
