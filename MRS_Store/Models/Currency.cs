using System;

namespace MRS_Store.Models
{
    public class Currency : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        public string CurrncyCode { get; set; }
        public string CurrencyName { get; set; }
        //public DateTime CreatedDateTime { get; set; }
    }
}