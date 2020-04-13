using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MRS_Store.Models
{
    public class Shift : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        [ForeignKey("Store")]
        public System.Nullable<Int64> StoreId { get; set; }
        public Store Store { get; set; } // Foreign Key from Stores Table

        [ForeignKey("Register")]
        public System.Nullable<Int64> RegisterId { get; set; }
        public Register Register { get; set; }
        //public DateTime CreatedDateTime { get; set; }

    }
}