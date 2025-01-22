using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Repository.IRepository;

namespace ApiFilms.Repository
{
    public class RepositoryCategory : IRespositoryCategory
    {
        private readonly ApplicationDBContext _db;

        public bool CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public bool ExistsCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsCategory(string Name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public bool save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
