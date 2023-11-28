using System.Collections.Generic;

namespace Puffix.Mvvm.Router;

/// <summary>
/// Publish / Subscribe router
/// </summary>
/// <typeparam name="T"></typeparam>
public static class PubSubRouter<T>
{

    private static readonly IDictionary<string, PubSubRouterEventHandler<T>> events = new Dictionary<string, PubSubRouterEventHandler<T>>();

    /// <summary>
    /// Add a new routage event
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="handler">Handler</param>
    public static void AddEvent(string name, PubSubRouterEventHandler<T> handler)
    {
        if (!events.ContainsKey(name))
            events.Add(name, handler);
    }

    /// <summary>
    /// Raise a new event
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="sender">Sender</param>
    /// <param name="args">Event arguments</param>
    public static void RaiseEvent(string name, object sender, PubSubRouterEventArgs<T> args)
    {
        if (events.ContainsKey(name) && events[name] != null)
            events[name](sender, args);
    }

    /// <summary>
    /// Register a new envet
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="handler">Event handler</param>
    public static void RegisterEvent(string name, PubSubRouterEventHandler<T> handler)
    {
        if (events.ContainsKey(name))
            events[name] += handler;
    }
}
