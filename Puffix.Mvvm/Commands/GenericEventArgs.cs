using System;

namespace Puffix.Mvvm.Commands;

/// <summary>
/// Argument de type chaîne de caractères.
/// </summary>
public class GenericEventArgs<EventArgsT> : EventArgs
{
    /// <summary>
    /// Valeur de l'argument.
    /// </summary>
    public EventArgsT EventArgValue { get; }

    /// <summary>
    /// Constructeur.
    /// </summary>
    /// <param name="eventArgValue">Valeur de l'argument.</param>
    public GenericEventArgs(EventArgsT eventArgValue)
    {
        EventArgValue = eventArgValue;
    }
}
