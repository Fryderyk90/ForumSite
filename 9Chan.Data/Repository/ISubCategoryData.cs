using _9Chan.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public interface ISubCategoryData
    {
        Task<List<SubCategory>> AllSubCategories();

        Task<List<SubCategory>> AllSubCategoriesByCategoryId(int? id);

        Task<SubCategory> UpdateSubCategory(SubCategory subCategory);

        Task<SubCategory> GetSubCategoryById(int? id);

        Task<SubCategory> AddSubCategory(SubCategory newSubCategory);

        Task<SubCategory> DeleteSubCategory(SubCategory subcategory);

    //    Task DeleteSubCategories(SubCategory subcategory);
    }
}