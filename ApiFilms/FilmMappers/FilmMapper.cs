using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using AutoMapper;

namespace ApiFilms.FilmMapper;

public class FilmMapper : Profile //Automapper makes the communication and DTO mapping automatically
{
    public FilmMapper()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap(); //The connection can be between both in both directions
        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
        CreateMap<Film, FilmDTO>().ReverseMap();
        CreateMap<Film, CreateFilmDTO>().ReverseMap();
    }
}