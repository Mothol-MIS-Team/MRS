using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Linq;
namespace MRS_Store.Auth
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity _identity;

        public CustomIdentity CustomIdentity
        {
            get { return _identity ?? new AnonymousIdentity(); }
            set { _identity = value; }
        }

        #region IPrincipal Members
        IIdentity IPrincipal.Identity
        {
            get { return this.CustomIdentity; }
        }

        public bool IsInRole(string role)
        {
            
            return _identity.IsInRole(role);
        }
        #endregion
    }
}
