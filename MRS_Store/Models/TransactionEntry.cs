using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class TransactionEntry : DbObject
    {
        [ForeignKey("Transaction")]
        public System.Nullable<Int64> TransactionId { get; set; }
        public Transaction Transaction { get; set; } // Foreign Key from Transaction Table
        //public DateTime CreatedDateTime { get; set; }
        public double DicsountAmount { get; set; } //  Entry Discount Only
        public double Amount{ get; set; } // Amount before sales tax
        public double SalesTax { get; set; } //  Entry Sales Tax
        public double NetAmount { get; set; } // Amount after sales tax
        public int RecallType { get; set; } //- Void- Suspend -etc. 
        public double Quantity { get; set; } // Total Quantities
        public string Comments { get; set; }

        [ForeignKey("Product")]
        public System.Nullable<Int64> ProductId { get; set; }
        public Product Product { get; set; }

    }
}
