using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _9Chan.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter a Title For the Category")]
        public string Title { get; set; }

        public string Description { get; set; }

        public int? SubCategoryId { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}