using ApiFilms.Data;
using ApiFilms.Models;
using ApiFilms.Repository.IRepository;

namespace ApiFilms.Repository
{
    public class RepositoryCategory : IRespositoryCategory
    {
        private readonly ApplicationDBContext _db;

        public RepositoryCategory(ApplicationDBContext db)
        {
            _db = db;
        }

        public bool CreateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _db.Category.Add(category);
            return Save();
        }

        public bool DeleteCategory(int CategoryId)
        {
            _db.Category.Remove(GetCategory(CategoryId));
            return Save();
        }

        public bool ExistsCategory(int Id)
        {
            return _db.Category.Any(x => x.Id == Id); //x represents the category
        }

        public bool ExistsCategory(string Name)
        {
            bool value = _db.Category.Any(x => x.Name.ToLower().Trim() == Name.ToLower().Trim());
            return value;
        }

        public ICollection<Category> GetCategories()
        {
            return _db.Category.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _db.Category.FirstOrDefault(x => x.Id == CategoryId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool UpdateCategory(Category category)
        {
            category.CreatedDate = DateTime.Now;
            //Fixing the PUT problem
            var existingCategory = _db.Category.Find(category.Id);
            if(existingCategory != null)
                _db.Entry(existingCategory).CurrentValues.SetValues(category);
            else
                _db.Category.Update(category);
            
            return Save();
        }
    }
}
