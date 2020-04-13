using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class Transaction : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        [ForeignKey("Store")]
        public System.Nullable<Int64> StoreId { get; set; }
        public Store Store { get; set; } // Foreign Key from Stores Table

        [ForeignKey("Shift")]
        public System.Nullable<Int64> ShiftId { get; set; }
        public Shift Shift { get; set; }

        [ForeignKey("Register")]
        public System.Nullable<Int64> RegisterId { get; set; }
        public Register Register { get; set; }

        [ForeignKey("User")]
        public System.Nullable<Int64> CasherId { get; set; }
        public User Casher { get; set; }

        [ForeignKey("Employee")]
        public System.Nullable<Int64> SalesRepId { get; set; }
        public Employee SalesRep { get; set; }

        [ForeignKey("Currency")]
        public System.Nullable<Int64> CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [ForeignKey("Customer")]
        public System.Nullable<Int64> CustomerId { get; set; }
        public Customer Customer { get; set; }
        public double TotalDicsountAmount { get; set; } // General Transaction Discount Only
        public double GrossAmount{ get; set; } // Amount before sales tax
        public double TotalSalesTax { get; set; } // Total Entries Sales Tax
        public double NetAmount { get; set; } // Amount after sales tax
        public double PaymentAmount { get; set; } // Total Customer Payment
        public double AmountToCustomer { get; set; } // Remaining Amount
        public string RecieptNumber { get; set; } // Receipt Schema Like: str01-cust02-302
        public  Int64 TransactionReference { get; set; } // Default value = current 'Transaction Id' --- Refer to original transaction in case like 'return transaction' 
        public int RecallType { get; set; } //- Void- Suspend -etc. 
        public int NumberOfLines { get; set; } // Count of transaction entries
        public double NumberOfProducts { get; set; } // Total Quantities
        public string Comments { get; set; }
        public int TransactionType { get; set; } // - Order = 3 - Sales = 1 - Return=2

    }
}
