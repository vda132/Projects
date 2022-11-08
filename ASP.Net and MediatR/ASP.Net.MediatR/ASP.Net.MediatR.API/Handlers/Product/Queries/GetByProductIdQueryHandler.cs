using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Queries;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Queries;

namespace ASP.Net.MediatR.API.Handlers.Product.Queries;

public class GetByProductIdQueryHandler : GetByIdQueryHandler<GetByIdQyery<ProductDto, int>, ProductDto, int>
{
    public GetByProductIdQueryHandler(IProductService service) : base(service) { }
}
