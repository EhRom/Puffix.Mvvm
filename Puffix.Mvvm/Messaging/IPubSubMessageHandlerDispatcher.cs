namespace Puffix.Mvvm.Messaging;

public interface IPubSubMessageHandlerDispatcher
{
    bool RegisterSubscriber<ValueT>(IPubSubSubscriber<ValueT> subscriber);

    int SendMessage<ValueT>(IPubSubMessage<ValueT> message);
}
