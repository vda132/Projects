using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Product.Commands;

public class CreateProductRangeCommandHandler : CreateCommandHandler<CreateCommand<ProductDto, int>, ProductDto, int>
{
    public CreateProductRangeCommandHandler(IProductService service) : base(service) { }
}
