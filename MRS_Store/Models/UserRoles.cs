using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MRS_Store.Models
{
    public class UserRoles : DbObject
    {
        [ForeignKey("User")]
        public System.Nullable<Int64> UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public System.Nullable<Int64> RoleId { get; set; }
        public Role Role { get; set; }
    }
}
