using BaltaDesafioBlazor.Shared.Models.Locality;
using BaltaDesafioBlazor.Shared.Models.Result;

namespace BaltaDesafioBlazor.Domain.Handlers.Queries;

public interface ILocalityQueryHandler
{
    Task<QueryResultModel<LocalityModel>> GetLocalityAsync(string id, CancellationToken cancellationToken = default);
    Task<QueryResultModel<List<LocalityModel>>> GetLocalitiesAsync(int page = 0, int pageSize = 50, string state = "", string city = "", CancellationToken cancellationToken = default);
}
