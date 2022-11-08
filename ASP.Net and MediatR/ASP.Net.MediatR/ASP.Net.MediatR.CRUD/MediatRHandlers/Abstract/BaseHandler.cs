using ASP.Net.MediatR.CRUD.ServiceLayer;

namespace ASP.Net.MediatR.CRUD.MediatRHandlers.Abstract
{
    public class BaseHandler<TDto, TId>
    {
        protected ICRUDService<TDto, TId> _service;
        public BaseHandler(ICRUDService<TDto, TId> service)
        {
            _service = service;
        }
    }
}
