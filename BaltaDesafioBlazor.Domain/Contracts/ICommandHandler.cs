namespace BaltaDesafioBlazor.Domain.Contracts;

public interface ICommandHandler<T> where T : ICommand
{
    Task<ICommandResult> ExecuteAsync(T command, CancellationToken cancellationToken = default);
}
