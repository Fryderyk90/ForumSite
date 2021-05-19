using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9Chan.Core.Models;

namespace _9Chan.Data.Repository
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public Task<List<SubCategory>> AllSubCategories()
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetSubCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
