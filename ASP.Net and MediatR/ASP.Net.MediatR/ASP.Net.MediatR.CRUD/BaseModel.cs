namespace ASP.Net.MediatR.CRUD
{
    public class BaseModel<TId> : IBaseModel<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
