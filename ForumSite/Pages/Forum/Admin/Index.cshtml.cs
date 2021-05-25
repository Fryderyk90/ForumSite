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
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPostRepository _postRepository;

        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Post> ReportedPosts { get; set; }
        
        public IndexModel(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _postRepository = postRepository;
        }

        public async Task OnGet()
        {
            Categories = await _categoryRepository.AllCategories();
            SubCategories = await _subCategoryRepository.AllSubCategories();
            ReportedPosts = await _postRepository.ReportedPosts();

        }
    }
}
