using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRS_Store.Models
{
    public class Register : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        [ForeignKey("Store")]
        public System.Nullable<Int64> StoreId { get; set; }
        public Store Store { get; set; } // Foreign Key from Stores Table
        //public DateTime CreatedDateTime { get; set; }
    }
}