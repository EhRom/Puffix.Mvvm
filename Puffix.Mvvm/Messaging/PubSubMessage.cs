namespace Puffix.Mvvm.Messaging;

public class PubSubMessage<ValueT>(string route, ValueT messageValue) : IPubSubMessage<ValueT>
{
    public ValueT Value { get; } = messageValue;

    public string Route { get; } = route;
}
