using Report_Processor_Service.Services.MessageProcessor;

namespace Report_Processor_Service.Services.MessageConsumer
{
    public interface IMessageConsumer<TMessage>
    {
        void StartConsuming(IMessageProcessor<TMessage> processor);
    }
}
