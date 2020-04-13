using MRS_Store.Auth;
using MRS_Store.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MRS_Store.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() : base(nameof(MainViewModel))
        {
            customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
        }
        CustomPrincipal customPrincipal;
        public User CurrentUser
        {
            get 
            {
                return customPrincipal.CustomIdentity.User;
            }
        }
    }
}
