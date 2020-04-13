using MRS_Store.Globals;
using MRS_Store.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading;
using System.Windows.Controls;
using System.Security;
using MRS_Store.Auth;
using MRS_Store.Views;
using System.Windows;

namespace MRS_Store.ViewModels
{
    public class AuthViewModel : ViewModelBase
    {
        #region Common
        /// Common Variables
        /// 
        private readonly IAuthenticationService _authenticationService;
        private  Command _loginCommand;
        private  Command _logoutCommand;
        private string _UserName;
        private string _Password;
        private string _ValidationMessage;
        public AuthViewModel(IAuthenticationService authenticationService) : base(nameof(AuthViewModel))
        {
            _authenticationService = authenticationService;
            _loginCommand = new Command(CanLogin, Login);
            _logoutCommand = new Command(CanLogout,Logout);
        }
        #region Properties
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged("UserName"); }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrator") ? "You are an administrator!"
                              : "You are NOT a member of the administrator group.");

                return "Not authenticated!";
            }
        }

        public string ValidationMessage
        {
            get { return _ValidationMessage; }
            set { _ValidationMessage = value; OnPropertyChanged("Status"); }
        }
        #endregion
        #region Commands
        public Command LoginCommand 
        { 
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new Command(
                         CanLogin, // can execute
                         Login); // execute function
                }
                return _loginCommand;
            }
        }

        public Command LogoutCommand 
        { 
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new Command(
                         CanLogout, // can execute
                         Logout); // execute function
                }
                return _logoutCommand;
            }
        }
        #endregion

        private void Login(object parameter)
        {
            Window currentWindow = parameter as Window;

            try
            {
                //Validate credentials through the authentication service
                User user = _authenticationService.AuthenticateUser(UserName, Password);

                //Get the current principal object
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");

                //Authenticate the user
                customPrincipal.CustomIdentity = new CustomIdentity(user.UserName, user);

                //Update UI
                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                UserName = string.Empty; //reset
                Password = string.Empty; //reset
                ValidationMessage = string.Empty;

                ShowView(null);
                currentWindow.Close();
            }
            catch (UnauthorizedAccessException)
            {
                ValidationMessage = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                ValidationMessage = string.Format("ERROR: {0}", ex.Message);
            }
        }
        private bool CanLogin(object parameter)
        {
            return true;//return !IsAuthenticated;
        }
        private void Logout(object parameter)
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                //customPrincipal.CustomIdentity = new AnonymousIdentity();
                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();
                _logoutCommand.RaiseCanExecuteChanged();
                ValidationMessage = string.Empty;
            }
        }
        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }

        public bool IsAuthenticated
        {
            get { return 
                  //false; } 
                  Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        private void ShowView(object parameter)
        {
            try
            {
                ValidationMessage = string.Empty;
                MainWindow main = new MainWindow();
                main.Show();
                UserControl view;
                if (parameter == null)
                    view = new POSView();
                else
                    view = new DashboardView();

                Globals.Session.Instance.mainWindow = main;
                main.Show();
                Globals.Session.Instance.SetNextView(view);
            }
            catch (SecurityException)
            {
                ValidationMessage = "You are not authorized!";
            }
        }
        #endregion

        #region ListView
        /// ListView Variables
        /// 
        #endregion

        #region CreateView
        /// CreateView Variables
        /// 
        #endregion

        #region UpdateView
        /// UpdateView Variables
        /// 
        #endregion

        #region Delete
        /// Delete Variables
        /// 
        #endregion

    }
}
