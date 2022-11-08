namespace ASP.Net.MediatR.CRUD.Result;

public class ExecResult
{
    public bool HasErrors { get; set; }
    public bool IsSystemError { get; set; }
    public IEnumerable<string> Errors { get; set; } = default!;
}

public class ExecResult<T>
{
    public T Data = default!;
    public bool HasErrors { get; set; }
    public bool IsSystemError { get; set; }
    public IEnumerable<string> Errors { get; set; } = default!;
}
