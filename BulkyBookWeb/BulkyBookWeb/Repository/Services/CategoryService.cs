using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repository.Services
{
    public class CategoryService<T> : ICategory<T> where T : class
    {
        public ApplicationDbContext context;
        DbSet<T> dbSet;
        public CategoryService(ApplicationDbContext context)
        {
                this.context = context;
                dbSet =  context.Set<T>();
        }

        #region GetCategory
        public async Task<IEnumerable<T>> GetCategoriesAsync()
        {
            var data = await dbSet.ToListAsync();

            return data;
        }
        #endregion

        #region Create
        public async Task<T> AddCategory(T category)
        {
           await dbSet.AddAsync(category);
           await context.SaveChangesAsync();
            return category;
        }
        #endregion

        #region Edit
        public async Task<T> EditCategory(int id)
        {
           var data = await dbSet.FindAsync(id);
            return data;
        }
        #endregion

        #region Update
        public async Task<bool> UpdateCategory(T category)
        {
            bool status = false;

            if (category != null)
            {
                context.Update(category);
                await context.SaveChangesAsync();
                status = true;
            }

            return status;
        }
        #endregion

        #region Delete
        public async Task<T> DeleteCategoryGet(int id)
        {
            var data = await dbSet.FindAsync(id);

            return data;
        }

        public async Task<bool> DeleteCategoryPost(T category)
        {
            var status = false;

            if(category != null)
            {
                 dbSet.Remove(category);
                 await context.SaveChangesAsync();
                 status = true;
            }

            return status;
        }
        #endregion

        #region Details
        public async Task<T> Details(int id)
        {
            var data = await dbSet.FindAsync(id);
            return data;
        }
        #endregion
    }
}
