using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class AddSubCategoryModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;
        public string Title { get; set; }

        [BindProperty]
        public SubCategory InputSubCategory { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public AddSubCategoryModel(ISubCategoryData subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet(string title, int id)
        {
            Title = title;
            SubCategories = await _subCategoryRepository.AllSubCategoriesInByCategoryId(id);
        }

        public async Task<RedirectToPageResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var newSubCategory = new SubCategory
                {
                    Title = InputSubCategory.Title,
                    Description = InputSubCategory.Description,
                    CategoryId = id
                };
                await _subCategoryRepository.AddSubCategory(newSubCategory);
            }

            return RedirectToPage("/Forum/Admin/Index");
        }
    }
}