using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository.Interfaces
{
    public interface ICategory<T>
    {
         Task<IEnumerable<T>> GetCategoriesAsync();
         Task<T> AddCategory(T category);
        
         Task<T> EditCategory(int id);
         Task<bool> UpdateCategory(T category);

         Task<T> DeleteCategoryGet(int id);
         Task<bool> DeleteCategoryPost(T category);

         Task<T>Details(int id);
    }
}
