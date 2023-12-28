using EcoTrack.BL.Interfaces;
using EcoTrack.BL.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace EcoTrack.BL.Services.MessageSender
{
    public class RabbitMqMessageSender<TMessage> : IMessageSender<TMessage>
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IMessageSerializer<TMessage> _messageSerializer;
        private readonly RabbitMqConfiguration _options;
        private readonly IModel _channel;
        private readonly IConnection _connection;

        public RabbitMqMessageSender(
            ConnectionFactory connectionFactory,
            IOptionsMonitor<RabbitMqConfiguration> options,
            IMessageSerializer<TMessage> messageSerializer) 
        {
            _connectionFactory = connectionFactory ?? 
                throw new ArgumentNullException(nameof(connectionFactory));
            _messageSerializer = messageSerializer ?? 
                throw new ArgumentNullException(nameof(messageSerializer));
            _options = options.CurrentValue ?? 
                throw new ArgumentNullException(nameof(options));
            
            (_channel, _connection) = InitializeClient();
        }

        private (IModel, IConnection) InitializeClient()
        {
            _connectionFactory.HostName = _options.IpAddress;
            var connection = _connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic, true, false);

            return (model, connection);
        }

        public void SendMessage(TMessage message, string routingKey)
        {
            var bytes = _messageSerializer.SerializeToUtf8Bytes(message);
            _channel.BasicPublish(
                exchange: _options.ExchangeName,
                routingKey: routingKey,
                basicProperties: null,
                body: bytes,
                mandatory: false
                );
        }
    }
}
