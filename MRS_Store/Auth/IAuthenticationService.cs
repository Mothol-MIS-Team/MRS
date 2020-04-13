using MRS_Store.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRS_Store.Auth
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
    }
}
