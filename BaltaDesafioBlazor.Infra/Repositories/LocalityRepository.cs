using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;
using BaltaDesafioBlazor.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BaltaDesafioBlazor.Infra.Repositories;

internal class LocalityRepository(DataContext dataContext) : ILocalityRepository
{
    public async Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            return await dataContext.Localities
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        try
        {
            await dataContext.Localities
                .AddAsync(locality, cancellationToken)
                .ConfigureAwait(false);

            await dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default)
    {
        try
        {
            dataContext.Localities.Update(locality);

            await dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        try
        {
            await dataContext.Localities
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
