using System;
using System.Threading.Tasks;
using EasyNetQ;
using Hydra.Core.Mediator.Integration;

namespace Hydra.Core.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        IAdvancedBus AdvancedBus {get;}
        
        bool IsConnected { get; }

         void Publish<T>(T message) where T : IntegrationEvent;

         Task PublishAsync<T>(T message) where T : IntegrationEvent;

        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest: IntegrationEvent
            where TResponse: ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest: IntegrationEvent
            where TResponse: ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> respond)
            where TRequest: IntegrationEvent
            where TResponse: ResponseMessage;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest: IntegrationEvent
            where TResponse: ResponseMessage;
    }
}