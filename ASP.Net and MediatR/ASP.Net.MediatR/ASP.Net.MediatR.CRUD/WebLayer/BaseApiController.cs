using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP.Net.MediatR.CRUD.WebLayer;

public class BaseApiController : ControllerBase
{
    protected IMemoryCache _cache;
    protected IMapper _mapper;

    public BaseApiController(IMemoryCache cache, IMapper mapper)
    {
        this._cache = cache;
        this._mapper = mapper;
    }
}
