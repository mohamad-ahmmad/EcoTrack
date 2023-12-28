using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Interfaces;
using System.Text.Json;

namespace EcoTrack.BL.Services.MessageSerializer
{
    public class JsonMessageSerializer<TMessage> : IMessageSerializer<TMessage> where TMessage : class
    {
        public TMessage Deserialize(string message)
        {
            var deserializedMessage = JsonSerializer.Deserialize<TMessage>(message);
            return deserializedMessage ??
                throw new CannotDeserializeMessageException("Cannot be deserialized from json");
        }

        public string Serialize(TMessage message)
        {
            return JsonSerializer.Serialize<TMessage>(message);
        }
    }
}
