using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using MRS_Store.Models;
using MRS_Store.Models.Services;

namespace MRS_Store.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        public User AuthenticateUser(string _UserName, string _Password)
        {
            IDataService<User> users = new GenericDataService<User>(new StoreDbContextFactory());
            User user = users.Get((u) => u.UserName.Equals(_UserName) && u.Password.Equals(CalculateHash(_Password, _UserName)));
            if (user == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");

            return user ;
        }

        private string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}
