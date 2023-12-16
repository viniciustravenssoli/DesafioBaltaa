using BaltaDesafioBlazor.Domain.Contracts;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Delete;

public sealed class DeleteLocalityCommand(string id) : ICommand
{
    public string Id { get; } = id;

    public bool IsValid => throw new NotImplementedException();

    public IReadOnlyCollection<string> Errors => throw new NotImplementedException();
}
