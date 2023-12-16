using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Base;
using BaltaDesafioBlazor.Domain.Contracts;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;

public sealed class UpdateLocalityCommand(string id, string city, string state) : AbstractLocality(id, city, state), ICommand
{
    public bool IsValid => throw new NotImplementedException();

    public IReadOnlyCollection<string> Errors => throw new NotImplementedException();
}
