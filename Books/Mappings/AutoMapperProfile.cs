using AutoMapper;
using Books.Models.Domain;
using Books.Models.DTOs;
using Books.Models.DTOs.AuthorsDto;
using Books.Models.DTOs.DifficultiesDto;
using Books.Models.DTOs.GenresDto;
using Books.Models.DTOs.ImageDto;
using Books.Models.DTOs.PublishersDto;

namespace Books.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Authors
            CreateMap<Author, AddAuthorDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            
            //Books
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            //Difficulties
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<Difficulty, AddDifficultyDto>().ReverseMap();

            //Publisher
            CreateMap<Publisher, PublisherDto>().ReverseMap();

            //Genres
            CreateMap<Genre, GenreDto>().ReverseMap();

            //Images
            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Image, ImageUploadRequestDto>().ReverseMap();

            /*
            CreateMap<Author, AddAuthorDto>().ReverseMap()
                .ForMember(author => author.Name, option => option.MapFrom(author => author.Name));
                
            example for mapping when values are different between the domain and the dto classes

            */
        }


    }
}
