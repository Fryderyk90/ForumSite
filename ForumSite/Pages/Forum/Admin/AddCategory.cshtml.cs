using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class AddCategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        [BindProperty]
        public Category InputCategory { get; set; }

        public AddCategoryModel(ICategoryRepository categoryRepository)
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
            }


            return RedirectToPage("./Index");
        }
    }

}
