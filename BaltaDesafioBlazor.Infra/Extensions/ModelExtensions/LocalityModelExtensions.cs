using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Create;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;
using BaltaDesafioBlazor.Shared.Models.Locality;

namespace BaltaDesafioBlazor.Infra.Extensions.ModelExtensions;

public static class LocalityModelExtensions
{
    public static CreateLocalityCommand ToCreateCommand(this LocalityModel model)
    {
        return new(model.Id, model.City, model.State);
    }

    public static UpdateLocalityCommand ToUpdateCommand(this LocalityModel model)
    {
        return new(model.Id, model.City, model.State);
    }
}
