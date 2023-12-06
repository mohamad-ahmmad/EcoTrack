using EcoTrack.PL.Entities;

namespace EcoTrack.BL.Services.Users.Interfaces
{
    public interface IUsersService
    {
        public Task<User?> GetUserByIdAsync(int id);
        public Task AddUserAsync(User user);
        public Task<IEnumerable<User>> GetAllUsersAsync( 
            string? firstName,
            string? lastName,
            string? cityName,
            string? countryName,
            int pageSize,
            int page
            );
        public Task<bool> SaveChangesAsync();
        public Task DeleteUserAsync(long id);
        public Task<User?> GetUserByCredentials(string username, string password);
        public Task<IEnumerable<EnviromentalReport>> GetEnviromentalReportsAsync(long userId, int? topicId, int pageSize = 20, int page = 1);
        public Task UploadReportAsync(long userId ,IEnumerable<EnviromentalReport> reports);
    }
}
