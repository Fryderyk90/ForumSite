using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ForumSite.Pages.Forum
{
    public class SubCategoriesModel : PageModel
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public List<SubCategory> SubCategories { get; set; }

        public SubCategoriesModel(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task OnGet()
        {
            SubCategories = await _subCategoryRepository.AllSubCategories();
        }
    }
}
