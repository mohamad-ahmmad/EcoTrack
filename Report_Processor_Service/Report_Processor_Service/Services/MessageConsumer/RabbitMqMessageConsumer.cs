using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Report_Processor_Service.Models;
using Report_Processor_Service.Services.MessageProcessor;
using Report_Processor_Service.Services.MessageSerializer;

namespace Report_Processor_Service.Services.MessageConsumer
{
    public class RabbitMqMessageConsumer<TMessage> : IMessageConsumer<TMessage>
    {
        private readonly IMessageSerializer<TMessage> _serializer;
        private readonly RabbitMqConfiguration _options;

        public RabbitMqMessageConsumer(
            IMessageSerializer<TMessage> serializer,
            IConnection connection,
            IOptionsMonitor<RabbitMqConfiguration> options)
        {
            _serializer = serializer ?? 
                throw new ArgumentNullException(nameof(serializer));
            _connectionFactory = connection ?? 
                throw new ArgumentNullException(nameof(connection));
            _options = options.CurrentValue ?? 
                throw new ArgumentNullException(nameof(options));


            _channel = InitializeConsumer();
        }

        private IModel InitializeConsumer()
        {
            _connectionFactory.HostName = _options.IpAddress;
            var connection = _connectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic, true, false);
            var queueName = model.QueueDeclare().QueueName;
            model.QueueBind(queueName, _options.ExchangeName, _options.RoutingKey);


            return model;
        }
        public void StartConsuming(IMessageProcessor<TMessage> processor)
        {
            
        }
    }


}
