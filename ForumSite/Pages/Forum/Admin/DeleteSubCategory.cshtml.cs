using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;

        public string Title { get; set; }
        public SubCategory SubCategory { get; set; }

        public DeleteModel(ISubCategoryData subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            SubCategory = await _subCategoryRepository.GetSubCategoryById(id);
            if (SubCategory == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id, string previousTitle)
        {
            var subcategoryToDelete = await _subCategoryRepository.GetSubCategoryById(id);
            if (subcategoryToDelete == null)
            {
                return RedirectToPage("Pages/NotFound");
            }
            await _subCategoryRepository.DeleteSubCategory(subcategoryToDelete);

            return RedirectToPage("./AddSubCategory", new { id = subcategoryToDelete.CategoryId, title = previousTitle });
        }
    }
}