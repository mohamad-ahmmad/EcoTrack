namespace Report_Processor_Service.Services.MessageSerializer
{
    public interface IMessageSerializer<TMessage>
    {
        TMessage Deserialize(byte[] bytes);
    }
}
