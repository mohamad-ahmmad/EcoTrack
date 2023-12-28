namespace EcoTrack.BL.Interfaces
{
    public interface IMessageSender<TMessage>
    {
        void SendMessage(TMessage message, string routingKey);
    }
}
