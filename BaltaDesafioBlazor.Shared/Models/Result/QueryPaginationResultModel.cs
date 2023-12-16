namespace BaltaDesafioBlazor.Shared.Models.Result;

public class QueryPaginationResultModel<T>(bool success, T result, int total) : QueryResultModel<T>(success, result)
{
    public int Total = total;
}
