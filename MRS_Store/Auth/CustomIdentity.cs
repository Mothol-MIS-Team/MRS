using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using MRS_Store.Models;
using System.Linq;
using MRS_Store.Models.Services;

namespace MRS_Store.Auth
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity(string name, User user)
        {
            Name = name;
            User = user;
        }
        public string Name { get; private set; }
        public User User { get; private set; }
        public string AuthenticationType { get { return "Custom authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }

        public bool IsInRole(string RoleName)
        {
            IDataService<UserRoles> Table = new GenericDataService<UserRoles>(new StoreDbContextFactory());
            UserRoles userRole = Table.Get((r) => r.UserId.Equals(User.Id) && r.Role.RoleName.Equals(RoleName));
            if (userRole == null)
                return false;

            return true;
        }
    }
}
