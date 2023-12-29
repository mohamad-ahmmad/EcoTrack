namespace Report_Processor_Service.Services.MessageProcessor
{
    public interface IMessageProcessor<TMessage>
    {
        Task Process(TMessage message);
    }
}