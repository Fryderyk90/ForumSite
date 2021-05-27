using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class EditCategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        [BindProperty]
        public InputCategory InputModel { get; set; }

        public class InputCategory
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public Category Category { get; set; }

        public EditCategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task OnGet(int id)
        {
            Category = await _categoryRepository.GetCategoryById(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                Category = await _categoryRepository.GetCategoryById(id);

                Category.Title = InputModel.Title;
                Category.Description = InputModel.Description;

                await _categoryRepository.UpdateCategory(Category);

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}