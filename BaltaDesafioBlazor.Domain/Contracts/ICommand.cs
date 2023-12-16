namespace BaltaDesafioBlazor.Domain.Contracts;

public interface ICommand
{
    public bool IsValid { get; }
    public IReadOnlyCollection<string> Errors { get; }
}
