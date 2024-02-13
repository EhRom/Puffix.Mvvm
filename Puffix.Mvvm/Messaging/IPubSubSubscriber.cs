using Puffix.Mvvm.Commands;
using System;

namespace Puffix.Mvvm.Messaging;

public interface IPubSubSubscriber
{
    public const string RouteParameterName = "route";
    public const string NameParameterName = "name";

    string Route { get; }

    string Name { get; }
}

public interface IPubSubSubscriber<ValueT> : IPubSubSubscriber
{
    event EventHandler<GenericEventArgs<ValueT>> MessageReceived;

    bool SendMessage(IPubSubMessageHandlerDispatcher sender, ValueT messageValue);
}