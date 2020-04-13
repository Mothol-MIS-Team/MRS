using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRS_Store.Models
{
    public class Category : DbObject
    {
        public string Name { get; set; }
        [ForeignKey("Category")]
        public System.Nullable<Int64> ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}