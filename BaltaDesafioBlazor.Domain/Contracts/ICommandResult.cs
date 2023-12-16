namespace BaltaDesafioBlazor.Domain.Contracts;

public interface ICommandResult
{
    public string Id { get; }
    public string Message { get; }
    public IReadOnlyCollection<string> Errors { get; }
}
