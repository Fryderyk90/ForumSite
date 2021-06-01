using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class SubCategoriesModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;
        public List<SubCategory> SubCategories { get; set; }
        public string CategoryTitle { get; set; }

        public SubCategoriesModel(ISubCategoryData subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet(int id, string categoryTitle)
        {
            CategoryTitle = categoryTitle;
            SubCategories = await _subCategoryRepository.AllSubCategoriesInByCategoryId(id);
        }
    }
}