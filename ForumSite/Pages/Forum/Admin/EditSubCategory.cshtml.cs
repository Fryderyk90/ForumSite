using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum.Admin
{
    public class EditSubCategoryModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;

        public class InputSubCategory
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        [BindProperty]
        public InputSubCategory InputModel { get; set; }

        public SubCategory SubCategory { get; set; }

        public EditSubCategoryModel(ISubCategoryData subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet(int id)
        {
            
            var subCategory = await _subCategoryRepository.GetSubCategoryById(id);
            SubCategory = subCategory;

          
        }

        public async Task<IActionResult> OnPost(int id,string previousTitle)
        {
            if (ModelState.IsValid)
            {
                SubCategory = await _subCategoryRepository.GetSubCategoryById(id);
                SubCategory.Title = InputModel.Title;
                SubCategory.Description = InputModel.Description;
                await _subCategoryRepository.UpdateSubCategory(SubCategory);

                //  return RedirectToPage($"/Forum/Admin/AddSubCategory?id={id}&title={previousTitle}");

                return Page();
            }

            return Page();
        }
    }
}