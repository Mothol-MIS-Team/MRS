using MRS_Store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRS_Store.Auth
{
    public class AnonymousIdentity : CustomIdentity
    {
        public AnonymousIdentity() : base(string.Empty, new User())
        { 
        }
    }
}
