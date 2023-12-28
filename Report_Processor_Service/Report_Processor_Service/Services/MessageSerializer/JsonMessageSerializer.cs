using System.Text.Json;
using System.Text;

namespace Report_Processor_Service.Services.MessageSerializer
{
    public class JsonMessageSerializer<TMessage> : IMessageSerializer<TMessage> where TMessage : class
    {
        public TMessage Deserialize(byte[] bytes)
        {
            var jsonMessage = Encoding.UTF8.GetString(bytes);
            var reportMessage = JsonSerializer.Deserialize<TMessage>(jsonMessage);
            return reportMessage!;
        }
    }
}
