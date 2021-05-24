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
    public class DeleteCategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        public Category Category { get; set; }

        public DeleteCategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> OnGet(int id)
        {

            Category = await _categoryRepository.GetCategoryById(id);
            if (Category == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            
            var category = await _categoryRepository.DeleteCategoryById(id);
            if (category == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./index");
        }

    }
}
