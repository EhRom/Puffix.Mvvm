using Puffix.Mvvm.Commands;
using System;

namespace Puffix.Mvvm.Messaging;

public class PubSubSubscriber<ValueT>(string route, string name) : IPubSubSubscriber<ValueT>
{
    public string Route { get; } = route;

    public string Name { get; } = name;

    public event EventHandler<GenericEventArgs<ValueT>> MessageReceived;

    public bool SendMessage(IPubSubMessageHandlerDispatcher sender, ValueT messageValue)
    {
        MessageReceived?.Invoke(sender, new GenericEventArgs<ValueT>(messageValue));

        return MessageReceived is not null;
    }
}