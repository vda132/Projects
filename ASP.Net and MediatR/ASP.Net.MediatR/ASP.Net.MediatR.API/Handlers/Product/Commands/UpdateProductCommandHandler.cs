using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;
using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.API.Handlers.Product.Commands;

public class UpdateProductCommandHandler : UpdateCommandHandler<UpdateCommand<ProductDto, int>, ProductDto, int>
{
    public UpdateProductCommandHandler(IProductService service) : base(service) { }
}
