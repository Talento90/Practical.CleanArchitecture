using System;

namespace ClassifiedAds.Modules.MessageBorkers.Contracts.Services
{
    public interface IMessageBusReceiver<T>
    {
        void Receive(Action<T> action);
    }
}
