using BaltaDesafioBlazor.Domain.Handlers.Queries;
using BaltaDesafioBlazor.Infra.Data;
using BaltaDesafioBlazor.Shared.Models.Locality;
using BaltaDesafioBlazor.Shared.Models.Result;
using Microsoft.EntityFrameworkCore;

namespace BaltaDesafioBlazor.Infra.Queries;

internal class LocalityQueryHandler(IDbContextFactory<DataContext> contextFactory) : ILocalityQueryHandler
{
    public async Task<QueryPaginationResultModel<List<LocalityModel>>> GetLocalitiesAsync(int page = 0, int pageSize = 50, string state = "", string city = "", CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = contextFactory.CreateDbContext();
            var query = context.Localities
                .AsNoTracking()
                .Where(i =>
                string.IsNullOrWhiteSpace(i.State) ||
                string.IsNullOrWhiteSpace(i.City) ||
                i.State.Contains(state, StringComparison.OrdinalIgnoreCase) ||
                i.City.Contains(city, StringComparison.OrdinalIgnoreCase))
                .OrderBy(i => i.Id);

            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            var result = await query
                .Select(i => new LocalityModel
                {
                    Id = i.Id,
                    City = i.City,
                    State = i.State,
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new(true, result, total);
        }
        catch (Exception)
        {
            return new QueryPaginationResultModel<List<LocalityModel>>(false, [], 0);
        }
    }

    public async Task<QueryResultModel<LocalityModel>> GetLocalityAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var context = contextFactory.CreateDbContext();
            var result = await context.Localities
                .AsNoTracking()
                .Where(i => i.Id == id)
                .Select(i => new LocalityModel
                {
                    Id = i.Id,
                    City = i.City,
                    State = i.State
                })
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            return new(true, result ?? new());
        }
        catch (Exception)
        {
            return new(false, new());
        }
    }
}
