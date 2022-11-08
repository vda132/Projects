using ASP.Net.MediatR.API.ViewModels.Order;
using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.WebLayer;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.Net.MediatR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : CRUDController<CreateOrderDetailViewModel, OrderDetailViewModel, OrderDetailDto, int>
    {
        public OrderDetailsController(IMediator mediator, IMemoryCache cache, IMapper mapper) : base(mediator, cache, mapper)
        {
        }
    }
}
