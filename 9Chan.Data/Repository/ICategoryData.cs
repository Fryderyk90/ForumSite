using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface ICategoryData
    {
        Task<List<Category>> AllCategories();

        Task<Category> GetCategoryById(int id);

        Task<Category> AddCategory(Category newCategory);

        Task<Category> DeleteCategoryById(int id);

        Task<Category> UpdateCategory(Category updatedCategory);
    }
}