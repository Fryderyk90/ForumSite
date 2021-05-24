using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> AllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> AddCategory(Category newCategory);

        Task<Category> DeleteCategoryById(int id);
        Task<Category> UpdateCategory(Category updatedCategory);
    }
}
