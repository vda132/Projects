using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Helpers;
using ASP.Net.MediatR.Contacts.Repositories;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.Result;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.Services.Services;

public class UserService : CRUDService<IUserRepository, UserDto, Guid>, IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    public UserService(IUserRepository repository, IPasswordHasher passwordHasher) : base(repository)
    {
        _passwordHasher = passwordHasher;
    }

    public override async Task<ExecResult<Guid>> AddAsyns(UserDto model, CancellationToken cancellationToken)
    {
        var newPassword = await _passwordHasher.HashPassword(model.Password);
        model.Password = newPassword;
        
        return await base.AddAsyns(model, cancellationToken);
    }

    public override async Task<ExecResult<IEnumerable<Guid>>> AddRangeAsync(IEnumerable<UserDto> models, CancellationToken cancellationToken)
    {
        foreach (var model in models)
        {
            var newPassword = await _passwordHasher.HashPassword(model.Password);
            model.Password = newPassword;
        }

        return await base.AddRangeAsync(models, cancellationToken);
    }
}
