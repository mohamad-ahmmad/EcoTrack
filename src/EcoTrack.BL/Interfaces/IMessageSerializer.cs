namespace EcoTrack.BL.Interfaces
{
    public interface IMessageSerializer<TMessage>
    {
        string Serialize(TMessage message);
        TMessage Deserialize(string message);
    }
}