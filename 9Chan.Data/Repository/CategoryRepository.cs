using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ForumSiteContext _context;

        public CategoryRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> AllCategories()
        {

            return await _context.Categories.ToListAsync();

        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public async Task<Category> AddCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public Category RemoveCategoryById(int id)
        {
            var category = GetCategoryById(id);
            return category;
        }
    }
}
