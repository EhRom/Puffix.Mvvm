namespace Puffix.Mvvm.Messaging;

public interface IPubSubMessage
{
    public const string RouteParameterName = "route";
    public const string MessageValueParameterName = "messageValue";

    string Route { get; }
}


public interface IPubSubMessage<ValueT> : IPubSubMessage
{
    ValueT Value { get; }
}
