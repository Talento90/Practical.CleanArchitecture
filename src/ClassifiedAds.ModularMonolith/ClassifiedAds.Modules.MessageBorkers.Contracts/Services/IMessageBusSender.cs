namespace ClassifiedAds.Modules.MessageBorkers.Contracts.Services
{
    public interface IMessageBusSender<T>
    {
        void Send(T message);
    }
}
