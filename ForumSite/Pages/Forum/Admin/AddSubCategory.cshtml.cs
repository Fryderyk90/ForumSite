using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class AddSubCategoryModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;
        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [BindProperty]
        public Input InputSubCategory { get; set; }

        public class Input
        {
            [Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
        }
        public List<SubCategory> SubCategories { get; set; }

        public AddSubCategoryModel(ISubCategoryData subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet(string title, int id)
        {
            Title = title;
            SubCategories = await _subCategoryRepository.AllSubCategoriesByCategoryId(id);
        }

        public async Task<IActionResult> OnPost(int id)
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
            SubCategories = await _subCategoryRepository.AllSubCategoriesByCategoryId(id);
            return Page();
        }
    }
}