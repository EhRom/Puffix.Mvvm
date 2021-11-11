using System.Collections.Generic;

namespace Puffix.Mvvm.Router
{
    public static class PubSubRouter<T>
    {
        private static readonly IDictionary<string, PubSubRouterEventHandler<T>> events = new Dictionary<string, PubSubRouterEventHandler<T>>();

        public static void AddEvent(string name, PubSubRouterEventHandler<T> handler)
        {
            if (!events.ContainsKey(name))
                events.Add(name, handler);
        }

        public static void RaiseEvent(string name, object sender, PubSubRouterEventArgs<T> args)
        {
            if (events.ContainsKey(name) && events[name] != null)
                events[name](sender, args);
        }

        public static void RegisterEvent(string name, PubSubRouterEventHandler<T> handler)
        {
            if (events.ContainsKey(name))
                events[name] += handler;
        }
    }
}
