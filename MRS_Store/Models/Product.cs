using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRS_Store.Models
{
    public class Product : DbObject
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        public System.Nullable<Int64> CategoryId { get; set; }
        public Category Category { get; set; }
    }
}