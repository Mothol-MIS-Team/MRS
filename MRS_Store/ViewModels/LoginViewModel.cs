using MRS_Store.Auth;
using MRS_Store.Models;
using MRS_Store.Models.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace MRS_Store.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Define as Singleton
        private static LoginViewModel _instance;

        public static LoginViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoginViewModel();
                }
                return (_instance);
            }
        }
        public LoginViewModel() :base(nameof(LoginViewModel))
        {
        }
        #endregion

        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set 
            { _UserName = value;}
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private string _ValidationMessage;

        public string ValidationMessage
        {
            get { return _ValidationMessage; }
            set { _ValidationMessage = value; }
        }

        public ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new Command(
                        p => true, // can execute
                        p => LoginUser()); // execute function
                }
                return loginCommand;
            }
        }

        /*public bool LoginUser()
        {
            IDataService<User> users = new GenericDataService<User>(new StoreDbContextFactory());
            User user = users.Get((u) => u.UserName.Equals(_UserName) && u.Password.Equals(Incoder(_Password, _UserName)));
            if (user == null)
                return false;
            else
            {
                Globals.Session.Instance.User = user;
                return true;
            }


        }*/
        public void LoginUser()
        {
            if (!string.IsNullOrEmpty(_UserName) && !string.IsNullOrEmpty(_Password))
            {
                IDataService<User> users = new GenericDataService<User>(new StoreDbContextFactory());
                User user = users.Get((u) => u.UserName.Equals(_UserName) && u.Password.Equals(Incoder(_Password, _UserName)));
                if (user == null)
                    ValidationMessage = "Wrong Password or Username !";
                else
                {
                    CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                    if (customPrincipal == null)
                        throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                    customPrincipal.CustomIdentity = new CustomIdentity(user.UserName, user);
                    MainWindow main = new MainWindow();
                    main.Show();
                    //return true;
                }
            }
            else
            {
                ValidationMessage = "Empty Password or Username !";
            }

        }
        public string Incoder(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
        /*private string Decoder(string HashedPassword, string salt)
        {

            byte[] hash =  Convert.FromBase64String(HashedPassword);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.(saltedHashBytes);

            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }*/
    }
}
