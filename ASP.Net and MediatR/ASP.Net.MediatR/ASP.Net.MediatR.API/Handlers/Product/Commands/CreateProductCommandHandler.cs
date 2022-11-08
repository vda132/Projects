using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Product.Commands;

public class CreateProductCommandHandler : CreateCommandHandler<CreateCommand<ProductDto, int>, ProductDto, int>
{
    public CreateProductCommandHandler(IProductService service) : base(service) { }
}
