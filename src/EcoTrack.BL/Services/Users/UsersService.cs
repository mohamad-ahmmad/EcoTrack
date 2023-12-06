using EcoTrack.BL.Exceptions;
using EcoTrack.BL.Services.Users.Interfaces;
using EcoTrack.PL.Entities;
using EcoTrack.PL.Repositories.EnviromentalReports.Interfaces;
using EcoTrack.PL.Repositories.Users.Interface;
using System.Security.Cryptography;
using System.Text;

namespace EcoTrack.BL.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEnviromentalReportsRepository _envRepRepository;
        public UsersService(IUserRepository userRepository, IEnviromentalReportsRepository envRepRepository)
        {
            _userRepository = userRepository;
            _envRepRepository = envRepRepository;
        }

        private static string HashPassword(string input)
        {
            var hasher = SHA256.Create();
            var hashedPassword =  hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Encoding.UTF8.GetString(hashedPassword);
        }

        public async Task AddUserAsync(User user)
        {
           var found= await _userRepository.IsFoundByUsernameAsync(user.Username);
            if (found)
            {
                throw new UsernameUsedException($"{user.Username} already used.");
            }
            user.Password= HashPassword(user.Password);
            await _userRepository.AddUserAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(
            string? firstName,
            string? lastName,
            string? cityName,
            string? countryName,
            int pageSize,
            int page)
        {
            pageSize = Math.Min(pageSize, 30);
            return await _userRepository.GetAllUsersAsync( 
                firstName?.ToLower(),
                lastName?.ToLower(),
                cityName?.ToLower(),
                countryName?.ToLower(),
                pageSize,
                page);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long id)
        {
            await UserExists(id);
            await _userRepository.DeleteUserAsync(id);
        }

        public Task<User?> GetUserByCredentials(string username, string password)
        {
            var hashedPassword = HashPassword(password);
            var user = _userRepository.GetUserByCredentials(username, hashedPassword);
            return user;
        }

        public async Task<IEnumerable<EnviromentalReport>> GetEnviromentalReportsAsync(long userId, int? topicId ,int pageSize = 20, int page = 1)
        {
            pageSize = Math.Min(pageSize, 20);
            page = Math.Max(page, 1);

            await UserExists(userId);

            return await _envRepRepository.GetEnviromentalReportsAsync(userId, topicId, pageSize, page);
        }

        private async Task UserExists(long userId)
        {
            var isFound = await _userRepository.IsFoundByUserIdAsync(userId);
            if (!isFound)
            {
                throw new NotFoundUserException($"User with {userId} id not found.");
            }
        }

        public async Task UploadReportAsync(long userId ,IEnumerable<EnviromentalReport> reports)
        {
            //Auth occurs in the api layer.
            await _envRepRepository.AddReports(userId ,reports);
        }
    }
}
