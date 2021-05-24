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

        public async Task<List<SubCategory>> AllSubCategoriesById(int id)
        {
            return await _context.SubCategories.Where(sb => sb.CategoryId == id).ToListAsync();
             
        }

        public async Task<SubCategory> UpdateSubCategory(SubCategory updatedSubCategory)
        {

            var entity = _context.SubCategories.Attach(updatedSubCategory);
           
            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updatedSubCategory;
        }

        public async Task<SubCategory> GetSubCategoryById(int? id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);

            return subcategory;




        }

        public async Task<SubCategory> AddSubCategory(SubCategory newSubCategory)
        {
            var categories = await _context.Categories.ToArrayAsync();
            var inputSubCategory = newSubCategory;
            await _context.SubCategories.AddAsync(newSubCategory); 
            await _context.SaveChangesAsync();
            return newSubCategory;
        }

        public async Task<SubCategory> DeleteSubCategory(int? subCategoryId)
        {
            var categories = _context.Categories.ToArrayAsync();
            var subCategory = GetSubCategoryById(subCategoryId);
          
                _context.SubCategories.Remove(await subCategory);
                await _context.SaveChangesAsync();
            

            return await subCategory;
        }
    }
}
