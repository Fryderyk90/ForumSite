using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class EditSubCategoryModel : PageModel
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public class InputSubCategory
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        [BindProperty]
        public InputSubCategory InputModel { get; set; }

        public SubCategory SubCategory { get; set; }

        public EditSubCategoryModel(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IActionResult> OnGet(int? subCategoryId)
        {
            SubCategory = await _subCategoryRepository.GetSubCategoryById(subCategoryId);

            return Page();
        }

        public async Task<IActionResult> OnPost(int subCategoryId)
        {
            if (ModelState.IsValid)
            {
                SubCategory = await _subCategoryRepository.GetSubCategoryById(subCategoryId);
                SubCategory.Title = InputModel.Title;
                SubCategory.Description = InputModel.Description;
                await _subCategoryRepository.UpdateSubCategory(SubCategory);
                return RedirectToPage("./index/AddSubCategory");
            }

            return Page();
        }
    }
}