using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public string Title { get; set; }
        public SubCategory SubCategory { get; set; }

        public DeleteModel(ISubCategoryRepository subCategoryRepository)
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

        public async Task<IActionResult> OnPost(int id)
        {


            var subcategoryToDelete = await _subCategoryRepository.GetSubCategoryById(id);
            if (subcategoryToDelete == null)
            {
                return RedirectToPage("Pages/NotFound");
            }
            await _subCategoryRepository.DeleteSubCategories(subcategoryToDelete.Id);

            return RedirectToPage("./Index/AddSubCategory");
        }
    }
}
