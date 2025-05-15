namespace Puffix.Mvvm.Router;

/// <summary>
/// Publish / Subscribe router event argument
/// </summary>
/// <typeparam name="T">Event arguments type</typeparam>
public class PubSubRouterEventArgs<T>(T item)
{
    public T Item { get; set; } = item;
}
