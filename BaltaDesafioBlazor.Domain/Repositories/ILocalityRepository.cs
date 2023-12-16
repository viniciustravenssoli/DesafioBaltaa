using BaltaDesafioBlazor.Domain.Entities;

namespace BaltaDesafioBlazor.Domain.Repositories;

public interface ILocalityRepository
{
    Task<Locality?> GetAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> CreateAsync(Locality locality, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Locality locality, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
}
