using _9Chan.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9Chan.Data.Repository
{
    public class SubCategoryData : ISubCategoryData
    {
        private readonly ForumSiteContext _context;
        private readonly IThreadData _threadRepository;
        private readonly IPostData _postRepository;

        public SubCategoryData(ForumSiteContext context, IThreadData threadRepository, IPostData postRepository)
        {
            _context = context;
            _threadRepository = threadRepository;
            _postRepository = postRepository;
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

        public async Task<SubCategory> DeleteSubCategory(int id)
        {
            var subCategory = await GetSubCategoryById(id);
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();

            return subCategory;
        }

        public async Task DeleteSubCategories(int id)
        {
            var threadsToDelete = await _threadRepository.GetThreadsInSubCategoryById(id);
            var postsInToDelete = await _postRepository.GetPostsInThreadById(id);
            var subCategoriesToDelete = await AllSubCategoriesById(id);

            if (postsInToDelete.Count > 0)
            {
                await _postRepository.DeletePostsInThread(postsInToDelete);
            }
            if (threadsToDelete.Count > 0)
            {
                await _threadRepository.DeleteThreadsById(threadsToDelete);
            }

            if (subCategoriesToDelete.Count > 0)
            {
                foreach (var subCategory in subCategoriesToDelete)
                {
                    _context.SubCategories.Remove(subCategory);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}