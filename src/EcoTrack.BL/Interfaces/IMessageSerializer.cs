namespace EcoTrack.BL.Interfaces
{
    public interface IMessageSerializer<TMessage>
    {
        string Serialize(TMessage message);
        TMessage Deserialize(string message);
        byte[] SerializeToUtf8Bytes(TMessage message);
    }
}