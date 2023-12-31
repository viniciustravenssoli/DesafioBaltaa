﻿using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Create;
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
    public async Task<GenericCommandResult> ExecuteAsync(CreateLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var locality = new Locality(command.Id, command.City, command.State);
        var result = await localityRepository
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

        bool result;

        var locality = new Locality(command.Id, command.City, command.State);

        if (command.OldId == command.Id)
        {
            result = await localityRepository
                .UpdateAsync(locality, cancellationToken)
                .ConfigureAwait(false);
        }
        else
        {
            result = await localityRepository
                .DeleteAndUpdateAsync(command.OldId, locality, cancellationToken)
                .ConfigureAwait(false);
        }

        return result
            ? GenericCommandResult.SuccessResult(locality.Id)
            : GenericCommandResult.ErrorResult(["Erro ao atualizar localidade"]);
    }

    public async Task<GenericCommandResult> ExecuteAsync(DeleteLocalityCommand command, CancellationToken cancellationToken = default)
    {
        if (!command.IsValid)
            return GenericCommandResult.ErrorResult(command.Errors);

        var result = await localityRepository
            .DeleteAsync(command.Id, cancellationToken)
            .ConfigureAwait(false);

        return result
            ? GenericCommandResult.SuccessResult(command.Id)
            : GenericCommandResult.ErrorResult(["Erro ao deletar localidade"]);
    }
}
