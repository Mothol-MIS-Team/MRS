using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class Account : DbObject
    {
        //public int Id { get; set; }
        [ForeignKey("User")]
        public System.Nullable<Int64> AccountHolderId { get; set; }
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        //public IEnumerable<AssetTransaction> AssetTransaction { get; set; }

    }
}
 