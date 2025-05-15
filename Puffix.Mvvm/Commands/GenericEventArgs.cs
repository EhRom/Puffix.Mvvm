using System;

namespace Puffix.Mvvm.Commands;

/// <summary>
/// Argument de type chaîne de caractères.
/// </summary>
public class GenericEventArgs<EventArgsT>(EventArgsT eventArgValue) : EventArgs
{
    /// <summary>
    /// Valeur de l'argument.
    /// </summary>
    public EventArgsT EventArgValue { get; } = eventArgValue;
}
