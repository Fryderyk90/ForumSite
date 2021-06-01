using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class EditCategoryModel : PageModel
    {
        private readonly ICategoryData _categoryData;

        [BindProperty]
        public InputCategory InputModel { get; set; }

        public class InputCategory
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public Category Category { get; set; }

        public EditCategoryModel(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        public async Task OnGet(int id)
        {
            var category = await _categoryData.GetCategoryById(id);
            Category = category;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                Category = await _categoryData.GetCategoryById(id);

                Category.Title = InputModel.Title;
                Category.Description = InputModel.Description;

                await _categoryData.UpdateCategory(Category);

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}