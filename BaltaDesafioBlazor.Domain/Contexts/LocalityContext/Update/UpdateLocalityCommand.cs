﻿using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Base;
using BaltaDesafioBlazor.Domain.Contracts;
using BaltaDesafioBlazor.Domain.Extensions;

namespace BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Update;

public sealed class UpdateLocalityCommand(string oldId, string newId, string city, string state) : AbstractLocality(newId, city, state), ICommand
{
    public string OldId { get; } = oldId;

    public bool IsValid
        => Validate().IsValid;

    public IReadOnlyCollection<string> Errors
        => Validate().GetErrors();
}
