using AutoMapper;
using BookReviewApp.Backend.Core.Context;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;
using BookReviewApp.Backend.Core.Enum;
using BookReviewApp.Backend.Core.ImagePathFolder;
using BookReviewApp.Backend.Core.PasswordService;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace BookReviewApp.Backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public UserService(AppDbContext dbcontext, IMapper _mapper)
        {
            context = dbcontext;
            mapper = _mapper;
        }

        public async Task<User> Register(UserCreateDto dto)
        {
            try
            {
                var existingUser = await context.Users
                                        .Where(u => u.Username == dto.Username && 
                                        u.Password == dto.Password)
                                        .FirstOrDefaultAsync();

                if (existingUser != null)
                    throw new InvalidOperationException("Username and Password already exists");

                var profilePath = await new ImageDirectory().profileImages(dto.Image);

                var newUser = mapper.Map<User>(dto);
                newUser.Password = PasswordHasher.HashPassword(dto.Password);
                newUser.UserRole = UserRole.User;
                newUser.Image = profilePath;

                context.Users.Add(newUser);
                await context.SaveChangesAsync();   

                return newUser;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> Login(UserLoginDto dto)
        {
            try
            {
                User user = await context.Users
                                        .Where(u => u.Username == dto.UsernameOrEmail)
                                        .FirstOrDefaultAsync();

                if (user == null)
                    user = await context.Users
                                        .Where(u => u.Email == dto.UsernameOrEmail)
                                        .FirstOrDefaultAsync();

                if (string.IsNullOrWhiteSpace(dto.UsernameOrEmail))
                    throw new AuthenticationException("Either Email or Username must be provided.");

                if (user == null)
                    throw new InvalidOperationException("User not found");

                if (!PasswordHasher.VerifyPassword(dto.Password, user.Password))
                    throw new AuthenticationException("Invalid Password");

                return mapper.Map<User>(user);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<List<User>> GetAlUser()
            => await context.Users
                            .Where(u => u.UserRole == UserRole.User)
                            .ToListAsync();

        public async Task<List<User>> GetByUserId(int id)
            => await context.Users
                            .Include(u => u.Reviews)
                            .Where(u => u.Id == id)
                            .ToListAsync();

        public async Task<User> UpdateProfileDetails(int id, UserUpdateProfileDetailsDto dto)
        {
            try
            {
                var user = await context.Users
                                        .Where(u => u.Id == id)
                                        .FirstOrDefaultAsync();

                if (user == null)
                    throw new InvalidOperationException("User not found");

                var newProfile = await new ImageDirectory().profileImages(dto.Image);

                mapper.Map(dto, user);
                user.Image = newProfile;
                user.Password = PasswordHasher.HashPassword(dto.Password);
                user.UserRole = UserRole.User;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> UserActivation(int id)
        {
            try
            {
                var user = await context.Users
                                        .Where(u => u.Id == id)
                                        .FirstOrDefaultAsync();
                if (user == null)
                    throw new InvalidOperationException("User not found");

                if (user.UserRole != UserRole.User)
                    throw new InvalidOperationException("Does not correspont to a user");

                user.IsActive = true;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> UserDeactivation(int id)
        {
            try
            {
                var user = await context.Users
                                        .Where(u => u.Id == id)
                                        .FirstOrDefaultAsync();
                if (user == null)
                    throw new InvalidOperationException("User not found");

                if (user.UserRole != UserRole.User)
                    throw new InvalidOperationException("Does not correspont to a user");

                user.IsActive = false;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> UserValidation(int id)
        {
            try
            {
                var user = await context.Users
                                        .Where(u => u.Id == id)
                                        .FirstOrDefaultAsync();
                if (user == null)
                    throw new InvalidOperationException("User not found");

                if (user.UserRole != UserRole.User)
                    throw new InvalidOperationException("Does not correspont to a admin");

                user.IsValidate = true;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User> Delete(int id)
        {
            try
            {
                var user = await context.Users
                                        .Where(u => u.Id == id)
                                        .FirstOrDefaultAsync();

                if (user == null)
                    throw new InvalidOperationException("User not found");

                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
