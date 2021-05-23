using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ForumSiteContext _context;

        public SubCategoryRepository(ForumSiteContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategory>> AllSubCategories()
        {
            return await _context.SubCategories.ToListAsync();
        }

        public Task<SubCategory> GetSubCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategory> AddSubCategory(SubCategory newSubCategory)
        {
            var inputSubCategory = newSubCategory;
            _context.SubCategories.Add(newSubCategory);
            _context.SaveChangesAsync();
            return newSubCategory;
        }
    }
}
