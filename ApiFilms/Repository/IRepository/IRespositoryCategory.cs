using ApiFilms.Models;

namespace ApiFilms.Repository.IRepository
{
    public interface IRespositoryCategory
    {
        ICollection<Category> GetCategories(); //all categories
        Category GetCategory(int categoryId); //one individual category
        bool ExistsCategory(int id);
        bool ExistsCategory(string name);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int CategoryId);
        bool Save();
    }
}
