using System;

namespace MRS_Store.Models
{
    public class Customer : DbObject
    {
        //public Int64 Id { get; set; } // Table Identity : 1
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string PersonalNumber { get; set; }
        //public DateTime CreatedDateTime { get; set; }
    }
}