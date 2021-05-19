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

        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
