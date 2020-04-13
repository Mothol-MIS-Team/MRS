using System;

namespace MRS_Store.Models
{
    public class PaymentType : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1

        public string Name { get; set; }
        //public DateTime CreatedDateTime { get; set; }
        public string Comments { get; set; }
    }
}