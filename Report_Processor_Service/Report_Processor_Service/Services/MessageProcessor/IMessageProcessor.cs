namespace Report_Processor_Service.Services.MessageProcessor
{
    public interface IMessageProcessor<TMessage>
    {
        void Process(TMessage message);
    }
}