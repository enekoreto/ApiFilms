using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Repository.IRepository;

namespace ApiFilms.Repository
{
    public class RepositoryFilm : IRespositoryFilm
    {
        private readonly ApplicationDBContext _db;

        public RepositoryFilm(ApplicationDBContext db)
        {
            _db = db;
        }

        public bool ExistsFilm(string name)
        {
            throw new NotImplementedException();
        }

        public bool CreateFilm(Film film)
        {
            film.CreatedDate = DateTime.Now;
            _db.Film.Add(film);
            return Save();
        }

        public bool DeleteFilm(Film filmId)
        {
            _db.Film.Remove(filmId);
            return Save();
        }

        public bool ExistsFilm(int id)
        {
            return _db.Film.Any(x => x.Id == id); //x represents the category
        }

        public bool ExistsCategory(string Name)
        {
            bool value = _db.Category.Any(x => x.Name.ToLower().Trim() == Name.ToLower().Trim());
            return value;
        }

        public ICollection<Film> GetFilms()
        {
            return _db.Film.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Film> GetFilmsInCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Film> SearchFilm(int name)
        {
            throw new NotImplementedException();
        }

        public Film GetFilm(int filmId)
        {
            return _db.Film.FirstOrDefault(x => x.Id == filmId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool UpdateFilm(Film film)
        {
            film.CreatedDate = DateTime.Now;
            _db.Film.Update(film);
            return Save();
        }
    }
}
