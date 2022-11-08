using ASP.Net.MediatR.API.ViewModels.User;
using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.ServiceLayer;
using ASP.Net.MediatR.CRUD.WebLayer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.Net.MediatR.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : CRUDController<CreateUserViewModel, UserViewModel, UserDto, Guid>
{
    public UsersController(IMediator mediator, IMemoryCache cache, IMapper mapper) : base(mediator, cache, mapper)
    {
    }
}
