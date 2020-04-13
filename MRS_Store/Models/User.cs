using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class User : DbObject
    {
        //public Int64 Id { get; set; } // table identity : 1
        public string UserId { get; set; } // User Name or User Code for login
        public string UserName { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }

        [ForeignKey("Employee")]
        public System.Nullable<Int64> EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
