using AutoMapper;
using BookReviewApp.Backend.Core.Dtos;
using BookReviewApp.Backend.Core.Entities;

namespace BookReviewApp.Backend.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            // User
            CreateMap<UserCreateDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserUpdateProfileDetailsDto, User>();

            // Book
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            // Book Category
            CreateMap<UpdateCategoryDto, BookCategory>();

            // Author 
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();

            // Review
            CreateMap<CreateReviewDto, Review>();
        }
    }
}
