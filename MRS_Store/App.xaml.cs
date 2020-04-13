using MRS_Store.Auth;
using MRS_Store.ViewModels;
using MRS_Store.Views.Login;
using System;
using System.Windows;

namespace MRS_Store
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		protected override void OnStartup(StartupEventArgs e)
		{
			//Create a custom principal with an anonymous identity at startup
			CustomPrincipal customPrincipal = new CustomPrincipal();
			AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);
			MRS_Store.Globals.Session.Instance.User = customPrincipal.CustomIdentity.User;
			//Show the login view
			Window window = new LoginView()
			{
				DataContext = new AuthViewModel(new AuthenticationService())
			};
			window.Show();
			base.OnStartup(e);
		}
	}
}
