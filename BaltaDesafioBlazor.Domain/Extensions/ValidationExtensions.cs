using FluentValidation.Results;

namespace BaltaDesafioBlazor.Domain.Extensions;

internal static class ValidationExtensions
{
    public static IReadOnlyCollection<string> GetErrors(this ValidationResult validation)
    {
        return validation.Errors.ConvertAll(x => x.ErrorMessage);
    }
}
