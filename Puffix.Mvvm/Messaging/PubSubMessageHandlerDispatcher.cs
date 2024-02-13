using System.Collections.Generic;
using System.Linq;

namespace Puffix.Mvvm.Messaging;

public class PubSubMessageHandlerDispatcher : IPubSubMessageHandlerDispatcher
{
    private readonly IDictionary<string, IDictionary<string, IPubSubSubscriber>> subscribers = new Dictionary<string, IDictionary<string, IPubSubSubscriber>>();

    private readonly object localLock = new object();

    public bool RegisterSubscriber<ValueT>(IPubSubSubscriber<ValueT> subscriber)
    {
        bool registered;

        lock (localLock)
        {
            if (!subscribers.ContainsKey(subscriber.Route))
                subscribers.Add(subscriber.Route, new Dictionary<string, IPubSubSubscriber>());

            if (!subscribers[subscriber.Route].ContainsKey(subscriber.Name))
            {
                subscribers[subscriber.Route].Add(subscriber.Name, subscriber);
                registered = true;
            }
            else
                registered = false;

        }
        return registered;
    }

    public int SendMessage<ValueT>(IPubSubMessage<ValueT> message)
    {
        int sentCount = 0;

        lock (localLock)
        {
            IEnumerable<IPubSubSubscriber<ValueT>> matchingSubscribers = subscribers.ContainsKey(message.Route) ?
            subscribers[message.Route].Values.Where(s => s is IPubSubSubscriber<ValueT>).Cast<IPubSubSubscriber<ValueT>>() : [];

            foreach (IPubSubSubscriber<ValueT> subscriber in matchingSubscribers)
            {
                sentCount += subscriber.SendMessage(this, message.Value) ? 1 : 0;
            }
        }

        return sentCount;
    }
}
