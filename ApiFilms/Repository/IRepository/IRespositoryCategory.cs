using ApiFilms.Models;

namespace ApiFilms.Repository.IRepository
{
    public interface IRespositoryCategory
    {
        ICollection<Category> GetCategories(); //all categories
        Category GetCategory(int CategoryId); //one individual category
        bool ExistsCategory(int Id);
        bool ExistsCategory(string Name);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int CategoryId);
        bool Save();
    }
}
