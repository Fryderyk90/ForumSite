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
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        public IEnumerable<Category> Categories { get; set; }

        [BindProperty]
        public Category InputCategory { get; set; }

        public SubCategory InputSubCategory { get; set; }

        public CategoryModel(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet()
        {
            Categories = await _categoryRepository.AllCategories();
        }
    }
}