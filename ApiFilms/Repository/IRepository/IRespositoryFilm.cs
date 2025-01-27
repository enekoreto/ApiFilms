using ApiFilms.Models;

namespace ApiFilms.Repository.IRepository
{
    public interface IRespositoryFilm
    {
        ICollection<Film> GetFilms(); //all categories
        ICollection<Film> GetFilmsInCategory(int categoryId);
        IEnumerable<Film> SearchFilm(string name);
        Film GetFilm(int filmId); //one individual category
        bool ExistsFilm(int id);
        bool ExistsFilm(string name);
        bool CreateFilm(Film film);
        bool UpdateFilm(Film film);
        bool DeleteFilm(int filmId);
        bool Save();
    }
}
