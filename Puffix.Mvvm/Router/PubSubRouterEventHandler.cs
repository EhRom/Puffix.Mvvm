namespace Puffix.Mvvm.Router;

/// <summary>
/// /// Publish / Subscribe router event handler
/// </summary>
/// <typeparam name="T">Argument type</typeparam>
/// <param name="sender">Sender</param>
/// <param name="args">Event arguments</param>
public delegate void PubSubRouterEventHandler<T>(object sender, PubSubRouterEventArgs<T> args);
