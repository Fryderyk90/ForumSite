using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumSite.Pages.Forum
{
    public class SubCategoriesModel : PageModel
    {
        private readonly ISubCategoryData _subCategoryRepository;
        private readonly IThreadData _threadData;
        public List<SubCategory> SubCategories { get; set; }
        public List<Thread> Threads { get; set; }
        public string CategoryTitle { get; set; }

        public List<SubCategoryTable> Table { get; set; }
        public class SubCategoryTable
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int ThreadCount { get; set; }
            public string LatestThreadTitle { get; set; }
            public string LatestThreadCreatedBy { get; set; }
            public DateTime LatestThreadDate { get; set; }
            public string LatestThreadUserId { get; set; }
            public int? CategoryId { get; set; }
        }

        public SubCategoriesModel(ISubCategoryData subCategoryRepository, IThreadData threadData)
        {
            _subCategoryRepository = subCategoryRepository;
            _threadData = threadData;
        }

        public async Task OnGet(int id, string categoryTitle)
        {
            CategoryTitle = categoryTitle;
            var subCategories = await _subCategoryRepository.AllSubCategoriesByCategoryId(id);
            var threads = await _threadData.GetThreadsInSubCategoryById(id);
            var table = CreateSubCategoryTable(subCategories);
            Table = table;

        }

        private List<SubCategoryTable> CreateSubCategoryTable(List<SubCategory> subCategories)
        {

            var subCategoryTable = new List<SubCategoryTable>();
            foreach (var subcategory in subCategories)
            {
                if (subcategory.Threads != null)
                {
                    foreach (var thread in subcategory.Threads.OrderByDescending(t => t.DateCreated).Take(1))
                    {

                        var item = new SubCategoryTable
                        {
                            Id = subcategory.Id,
                            Title = subcategory.Title,
                            Description = subcategory.Description,
                            ThreadCount = subcategory.Threads.Count(),
                            CategoryId = subcategory.CategoryId,

                            LatestThreadTitle = thread.Title,
                            LatestThreadCreatedBy = thread.User.UserName,
                            LatestThreadDate = thread.DateCreated,
                            LatestThreadUserId = thread.User.Id
                        };
                        subCategoryTable.Add(item);
                    }

                }
                else
                {
                    var item = new SubCategoryTable
                    {
                        Id = subcategory.Id,
                        Title = subcategory.Title,
                        Description = subcategory.Description,
                        ThreadCount = 0,
                        CategoryId = subcategory.CategoryId,

                        LatestThreadTitle = "No Threads",
                        LatestThreadCreatedBy = "",
                        LatestThreadDate = DateTime.ParseExact("22/11/2009", "dd/mm/yyyy",null),
                        LatestThreadUserId = null
                    };
                    subCategoryTable.Add(item);
                }
                    
                
                
            }

            return subCategoryTable;
        }
    }
}