using MRS_Store.Auth;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRS_Store.Views.Settings
{
    /// <summary>
    /// Interaction logic for SettengsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            if (CustomPrincipalPermission.Instance.Demand("Administrator"))
                InitializeComponent();
        }
        
    }
}
