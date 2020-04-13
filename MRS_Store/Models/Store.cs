using System;

namespace MRS_Store.Models
{
    public class Store : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        public string StoreName { get; set; }
        //public DateTime CreatedDateTime { get; set; }
    }
}