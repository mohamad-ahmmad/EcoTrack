using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report_Processor_Service.Models;
using Report_Processor_Service.Services.MessageProcessor;
using Report_Processor_Service.Services.MessageSerializer;
using System.Threading.Channels;

namespace Report_Processor_Service.Services.MessageConsumer
{
    public class RabbitMqMessageConsumer<TMessage> : IMessageConsumer<TMessage>
    {
        private readonly IMessageSerializer<TMessage> _serializer;
        private readonly RabbitMqConfiguration _options;
        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly string _queueName;

        public RabbitMqMessageConsumer(
            IMessageSerializer<TMessage> serializer,
            IConnection connection,
            IOptionsSnapshot<RabbitMqConfiguration> options)
        {
            _serializer = serializer ?? 
                throw new ArgumentNullException(nameof(serializer));
            _connection = connection ?? 
                throw new ArgumentNullException(nameof(connection));
            _options = options.Value ?? 
                throw new ArgumentNullException(nameof(options));


            (_channel, _queueName) = InitializeConsumer();
        }

        private (IModel, string) InitializeConsumer()
        {
            var model = _connection.CreateModel();

            model.ExchangeDeclare(_options.ExchangeName, ExchangeType.Topic, true, false);
            var queueName = model.QueueDeclare().QueueName;
            model.QueueBind(queueName, _options.ExchangeName, _options.RoutingKey);


            return (model, queueName);
        }
        public void StartConsuming(IMessageProcessor<TMessage> processor)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, message) => {
                try
                {
                    var deserializedMessage = _serializer.Deserialize(message.Body.ToArray());
                    await processor.Process(deserializedMessage);
                    _channel.BasicAck(message.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            };
            _channel.BasicConsume(_queueName, false, consumer);
        }
    }


}
