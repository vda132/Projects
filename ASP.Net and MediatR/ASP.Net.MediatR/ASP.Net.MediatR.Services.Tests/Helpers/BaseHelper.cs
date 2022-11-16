using ASP.Net.MediatR.CRUD.Result;

namespace ASP.Net.MediatR.Services.Tests.Helpers;

public abstract class BaseHelper<TId>
{
    public abstract IEnumerable<TId> CreateIds();
    public virtual ExecResult CreateExecResult(bool hasErrors, bool isSystemError, string[] errors) =>
        new ExecResult
        {
            HasErrors = hasErrors,
            IsSystemError = isSystemError,
            Errors = errors
        };

    public virtual ExecResult<T> CreateExecResult<T>(T data, bool hasErrors, bool isSystemError, string[] errors) =>
        new ExecResult<T>
        {
            Data = data,
            HasErrors = hasErrors,
            IsSystemError = isSystemError,
            Errors = errors
        };
}
