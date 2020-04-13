using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class TransactionPayment : DbObject
    {
        [ForeignKey("Transaction")]
        public System.Nullable<Int64> TransactionId { get; set; }
        public Transaction Transaction { get; set; } // Foreign Key from Transaction Table
        //public DateTime CreatedDateTime { get; set; }
        public double Amount { get; set; }

        [ForeignKey("PaymentType")]
        public System.Nullable<Int64> PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public string Comments { get; set; }
    }
}
