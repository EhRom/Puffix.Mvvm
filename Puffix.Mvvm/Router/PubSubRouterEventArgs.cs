namespace Puffix.Mvvm.Router;

/// <summary>
/// Publish / Subscribe router event argument
/// </summary>
/// <typeparam name="T">Event arguments type</typeparam>
public class PubSubRouterEventArgs<T>
{
    public T Item { get; set; }

    public PubSubRouterEventArgs(T item)
    {
        Item = item;
    }
}
