namespace BaltaDesafioBlazor.Domain.Contracts;

public interface ICommandResult
{
    public string Id { get; }
    public bool Success { get;}
    public string Message { get; }
    public IReadOnlyCollection<string> Errors { get; }
}

public class GenericCommandResult(string id, bool success, string message, IReadOnlyCollection<string> errors) : ICommandResult
{
    public string Id { get; } = id;

    public bool Success { get; } = success;

    public string Message { get; } = message;

    public IReadOnlyCollection<string> Errors { get; } = errors;

    public static GenericCommandResult SuccessResult(string id, string message = "") => new(id, true, message, []);
    public static GenericCommandResult ErrorResult(IReadOnlyCollection<string> errors, string message = "") => new(string.Empty, false, message, errors);
}
