using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Create;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Delete;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;
using BaltaDesafioBlazor.Domain.Contracts;

namespace BaltaDesafioBlazor.Domain.Handlers.Commands;

public sealed class LocalityHandler :
    ICommandHandler<CreateLocalityCommand, GenericCommandResult>,
    ICommandHandler<UpdateLocalityCommand, GenericCommandResult>,
    ICommandHandler<DeleteLocalityCommand, GenericCommandResult>
{
    public async Task<GenericCommandResult> ExecuteAsync(CreateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        throw new NotImplementedException();
    }

    public async Task<GenericCommandResult> ExecuteAsync(UpdateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        throw new NotImplementedException();
    }

    public async Task<GenericCommandResult> ExecuteAsync(DeleteLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        throw new NotImplementedException();
    }
}
