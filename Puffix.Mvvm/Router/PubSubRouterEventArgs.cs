namespace Puffix.Mvvm.Router
{
    public class PubSubRouterEventArgs<T>
    {
        public T Item { get; set; }

        public PubSubRouterEventArgs(T item)
        {
            Item = item;
        }
    }
}
