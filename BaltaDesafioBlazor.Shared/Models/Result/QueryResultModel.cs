namespace BaltaDesafioBlazor.Shared.Models.Result;

public class QueryResultModel<T>(bool success, T result)
{
    public bool Success { get; } = success;
    public T Result { get; } = result;
}
