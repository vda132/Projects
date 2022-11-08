using ASP.Net.MediatR.API.ViewModels.Product;
using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.WebLayer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.Net.MediatR.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : CRUDController<CreateProductViewModel, ProductViewModel, ProductDto, int>
{
    public ProductsController(IMediator mediator, IMemoryCache cache, IMapper mapper) : base(mediator, cache, mapper)
    {
    }
}
