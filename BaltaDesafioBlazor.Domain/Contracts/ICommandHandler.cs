namespace BaltaDesafioBlazor.Domain.Contracts;

public interface ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand
    where TCommandResult : ICommandResult
{
    Task<TCommandResult> ExecuteAsync(TCommand command, CancellationToken cancellationToken = default);
}
