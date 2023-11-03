using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Services
{
    public interface IUserService
    {
        public Task<User> Register(UserCreateDto dto);
        public Task<User> Login(UserLoginDto dto);
        public Task<List<User>> GetByUserId(int id);
        public Task<List<User>> GetAlUser();
        public Task<User> UpdateProfileDetails(int id, UserUpdateProfileDetailsDto dto);
        public Task<User> UserActivation(int id);
        public Task<User> UserDeactivation(int id);
        public Task<User> UserValidation(int id);
        public Task<User> Delete(int id);
    }
}
