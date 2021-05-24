using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp;

namespace ForumSite.Pages.Forum.Admin
{
    public class EditCategoryModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;

        [BindProperty]
        public Category Category { get; set; }
        [BindProperty]
        public string NewTitle { get; set; }
        [BindProperty]
        public string NewDescription { get; set; }

        public EditCategoryModel(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task OnGet(int id)
        {
            Category = await _categoryRepository.GetCategoryById(id);
        }

        public async Task OnPost()
        {
           
                Category.Title = NewTitle;
                Category.Description = NewDescription;
                await _categoryRepository.UpdateCategory(Category);
            
            
        }


    }
}
