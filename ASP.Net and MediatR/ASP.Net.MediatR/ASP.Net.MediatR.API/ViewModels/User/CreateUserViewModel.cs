using ASP.Net.MediatR.CRUD;
using System.ComponentModel.DataAnnotations;

namespace ASP.Net.MediatR.API.ViewModels.User;

public class CreateUserViewModel : BaseViewModel
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Login { get; set; } = default!;
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;
    [Required(ErrorMessage = "Role is required")]
    [Range(1, int.MaxValue)]
    public int RoleId { get; set; }
}
