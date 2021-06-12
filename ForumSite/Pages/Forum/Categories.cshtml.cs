using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryData _categoryData;
        private readonly ISubCategoryData _subCategoryData;
        public IEnumerable<Category> Categories { get; set; }

        [BindProperty]
        public Category InputCategory { get; set; }

        public SubCategory SubCategoryCount { get; set; }

        public CategoryModel(ICategoryData categoryRepository, ISubCategoryData subCategoryRepository)
        {
            _categoryData = categoryRepository;
            _subCategoryData = subCategoryRepository;
        }

        public async Task OnGet()
        {
            Categories = await _categoryData.AllCategories();
            
        }
    }
}