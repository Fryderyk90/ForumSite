using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategory>> AllSubCategories();
        Task<List<SubCategory>> AllSubCategoriesById(int id);
        Task<SubCategory> UpdateSubCategory(SubCategory subCategory);
        Task<SubCategory> GetSubCategoryById(int? id);
        Task<SubCategory> AddSubCategory(SubCategory newSubCategory);
        Task<SubCategory> DeleteSubCategory(int? subCategoryId);

    }
}
