using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Create;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Delete;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;
using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.Entities;
using BaltaDesafioBlazor.Domain.Repositories;

namespace BaltaDesafioBlazor.Domain.Handlers.Commands;

public sealed class LocalityHandler(ILocalityRepository localityRepository) :
    ICommandHandler<CreateLocalityCommand, GenericCommandResult>,
    ICommandHandler<UpdateLocalityCommand, GenericCommandResult>,
    ICommandHandler<DeleteLocalityCommand, GenericCommandResult>
{
    private readonly ILocalityRepository _localityRepository = localityRepository;

    public async Task<GenericCommandResult> ExecuteAsync(CreateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var locality = new Locality(command.Id, command.City, command.State);
        var result = await _localityRepository
            .CreateAsync(locality, cancellationToken)
            .ConfigureAwait(false);

        return result
            ? GenericCommandResult.SuccessResult(locality.Id)
            : GenericCommandResult.ErrorResult(["Erro ao criar localidade"]);
    }

    public async Task<GenericCommandResult> ExecuteAsync(UpdateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var locality = await _localityRepository
            .GetAsync(command.Id, cancellationToken)
            .ConfigureAwait(false);

        if (locality is null)
        {
            return GenericCommandResult.ErrorResult(["Localidade não encontrada"]);
        }

        locality.Update(command.Id, command.City, command.State);

        var result = await _localityRepository
            .UpdateAsync(locality, cancellationToken)
            .ConfigureAwait(false);

        return result
            ? GenericCommandResult.SuccessResult(locality.Id)
            : GenericCommandResult.ErrorResult(["Erro ao atualizar localidade"]);
    }

    public async Task<GenericCommandResult> ExecuteAsync(DeleteLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var result = await _localityRepository
            .DeleteAsync(command.Id, cancellationToken)
            .ConfigureAwait(false);

        return result
            ? GenericCommandResult.SuccessResult(command.Id)
            : GenericCommandResult.ErrorResult(["Erro ao deletar localidade"]);
    }
}
