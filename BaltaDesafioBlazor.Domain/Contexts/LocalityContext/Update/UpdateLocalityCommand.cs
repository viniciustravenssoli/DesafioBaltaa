using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Base;
using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.Extensions;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;

public sealed class UpdateLocalityCommand(string id, string city, string state) : AbstractLocality(id, city, state), ICommand
{
    public bool IsValid
        => Validate().IsValid;

    public IReadOnlyCollection<string> Errors
        => Validate().GetErrors();
}
