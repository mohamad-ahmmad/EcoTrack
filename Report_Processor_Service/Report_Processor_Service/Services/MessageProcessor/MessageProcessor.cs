namespace Report_Processor_Service.Services.MessageProcessor
{
    public class MessageProcessor<TMessage> : IMessageProcessor<TMessage>
    {
        public async Task ProcessAsync(TMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
