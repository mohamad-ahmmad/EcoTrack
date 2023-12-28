namespace EcoTrack.BL.Exceptions
{
    public class CannotDeserializeMessageException : Exception
    {
        public CannotDeserializeMessageException(string? message) : base(message)
        {
        }
    }
}
