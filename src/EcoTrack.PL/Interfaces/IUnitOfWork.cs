namespace EcoTrack.PL.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
