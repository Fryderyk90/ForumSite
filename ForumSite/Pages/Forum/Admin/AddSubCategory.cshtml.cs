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
    public class AddSubCategoryModel : PageModel
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public string Title { get; set; }
        [BindProperty]
        public SubCategory InputSubCategory { get; set; }

        public AddSubCategoryModel(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public void OnGet(string title)
        {
            Title = title;

        }

        public void OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var newSubCategory = new SubCategory
                {

                    Title = InputSubCategory.Title,
                    Description = InputSubCategory.Description,
                    CategoryId = id
                };
                _subCategoryRepository.AddSubCategory(newSubCategory);
            }

            RedirectToPage("./Forum/Admin/Index");

        }
    }
}
