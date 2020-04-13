using MRS_Store.ViewModels;
using MRS_Store.Views.Reports;
using MRS_Store.Views.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MRS_Store.Views.Main.Controls
{
    /// <summary>
    /// Interaction logic for SideMenu.xaml
    /// </summary>
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
        }
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc;
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.MainBody.Children.Clear();
            usc = ((ListViewItem)((ListView)sender).SelectedItem).Name switch
            {
                "Home" => new DashboardView(),
                "POS" => new POSView(),
                "Products" => new ProductsView(),
                "Customers" => new CustomersView(),
                "Reports" => new ReportsView(),
                "Settings" => new SettingsView(),
                _ => new DashboardView(),
            };
            parentWindow.MainBody.Children.Add(usc);
        }
        private void BtnOpenSideMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCloseSideMenu.Visibility = Visibility.Visible;
            btnOpenSideMenu.Visibility = Visibility.Collapsed;
        }
        private void BtnCloseSideMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCloseSideMenu.Visibility = Visibility.Collapsed;
            btnOpenSideMenu.Visibility = Visibility.Visible;
        }
    }
}
