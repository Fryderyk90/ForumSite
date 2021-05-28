using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class AddCategoryModel : PageModel
    {
        private readonly ICategoryData _categoryRepository;

        [BindProperty]
        public Category InputCategory { get; set; }

        public AddCategoryModel(ICategoryData categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Title = InputCategory.Title,
                    Description = InputCategory.Description
                };

                await _categoryRepository.AddCategory(newCategory);
                return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}