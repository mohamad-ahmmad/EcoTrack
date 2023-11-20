﻿using EcoTrack.PL.Entities;

namespace EcoTrack.PL.Repositories.Users.Interface
{
    public interface IUserRepository
    {
        public Task AddUserAsync(User user);
        public Task<User> GetUserById(int id);
    }
}
