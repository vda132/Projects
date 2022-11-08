namespace ASP.Net.MediatR.CRUD;

public interface IBaseModel<TId>
{
    public TId Id { get; set; }
}
