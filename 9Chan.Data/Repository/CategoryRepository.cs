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

        public async Task<Category> GetCategoryById(int id)
        {
            var subcategories = await _context.SubCategories.ToArrayAsync();
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<Category> AddCategory(Category newCategory)
        {
            var subcategories = await _context.SubCategories.ToArrayAsync();
            _context.Categories.Add(newCategory);
            
            await _context.SaveChangesAsync();
            return newCategory;
        }

        async Task<Category> ICategoryRepository.DeleteCategoryById(int id)
        {
            var subcategories = await _context.SubCategories.ToArrayAsync();
            var Category = await GetCategoryById(id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return  Category;
        }

        public async Task<Category> UpdateCategory(Category updatedCategory)
        {
            var entity = _context.Categories.Attach(updatedCategory);

            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updatedCategory;
        }

        
    }
}
