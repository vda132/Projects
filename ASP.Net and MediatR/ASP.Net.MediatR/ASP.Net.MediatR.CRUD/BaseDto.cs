namespace ASP.Net.MediatR.CRUD;
public class BaseDto<TId> : IBaseModel<TId>
{
    public TId Id { get; set; } = default!;
}