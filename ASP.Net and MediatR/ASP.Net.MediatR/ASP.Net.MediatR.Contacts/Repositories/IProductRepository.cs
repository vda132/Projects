using ASP.Net.MediatR.Contacts.Dto;
using ASP.Net.MediatR.CRUD.DbLayer;

namespace ASP.Net.MediatR.Contacts.Repositories;

public interface IProductRepository : ICRUDRepository<ProductDto, int>
{
}
