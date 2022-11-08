using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.Contacts.Services;
using ASP.Net.MediatR.CRUD.MediatR.Commands;
using ASP.Net.MediatR.CRUD.MediatRHandlers.Commands;

namespace ASP.Net.MediatR.API.Handlers.Product.Commands;

public class DeleteProductCommandHandler : DeleteCommandHandler<DeleteCommand<int>, ProductDto, int>
{
    public DeleteProductCommandHandler(IProductService service) : base(service) { }
}
