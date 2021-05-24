using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum.Admin
{
    
    public class EditSubCategoryModel : PageModel
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        [BindProperty]
        public SubCategory SubCategory { get; set; }
        [BindProperty]
        public string NewTitle { get; set; }
        [BindProperty]
        public string NewDescription { get; set; }
       
        public EditSubCategoryModel(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IActionResult> OnGet(int? subCategoryId)
        {
            SubCategory = await _subCategoryRepository.GetSubCategoryById(subCategoryId);


            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                //    await _subCategoryRepository.UpdateSubCategory(id,NewTitle,NewDescription);
                SubCategory.Title = NewTitle;
                SubCategory.Description = NewDescription;
                await _subCategoryRepository.UpdateSubCategory(SubCategory);
                return RedirectToPage("index");
            }

            return Page();
        }
    }
}
