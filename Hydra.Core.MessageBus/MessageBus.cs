using System;
using System.Threading.Tasks;
using EasyNetQ;
using Hydra.Core.Integration.Messages;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace Hydra.Core.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IBus _bus;

        private readonly string _connectionString;

        public MessageBus(string connectionString)
        {
            _connectionString = connectionString;
            TryConnect();
        }

        public bool IsConnected => _bus?.IsConnected ?? false;

        public void Publish<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            _bus.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : IntegrationEvent
        {
            TryConnect();
            await _bus.PublishAsync(message);
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Request<TRequest, TResponse>(request);
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.RequestAsync<TRequest, TResponse>(request);
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
            TryConnect();
            return _bus.Respond(respond);
        }

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> respond)
            where TRequest : IntegrationEvent
            where TResponse : ResponseMessage
        {
             TryConnect();
            return _bus.RespondAsync(respond);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            _bus.Subscribe(subscriptionId, onMessage);
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            TryConnect();
            _bus.SubscribeAsync(subscriptionId, onMessage);
        }

        private void TryConnect()
        {
            if(IsConnected) return;

            var policy = Policy.Handle<EasyNetQException>() //EasyNetQ exception
                                .Or<BrokerUnreachableException>() //RabbitMQ Exception
                                .WaitAndRetry(3, retryAttempt =>
                                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
            
            policy.Execute(() => { _bus = RabbitHutch.CreateBus(_connectionString); });
        }

        public void Dispose()
        {
            _bus.Dispose();
        }
    }
} 