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

namespace MRS_Store.Views.POS.Controls
{
    /// <summary>
    /// Interaction logic for SideFunctions.xaml
    /// </summary>
    public partial class SideFunctions : UserControl
    {
        public SideFunctions()
        {
            InitializeComponent();
        }
        
        private void ListViewFinctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*UserControl usc;
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.MainBody.Children.Clear();
            usc = ((ListViewItem)((ListView)sender).SelectedItem).Name switch
            {
                "Home" => new DashboardView(),
                "POS" => new POSView(),
                _ => new DashboardView(),
            };
            parentWindow.MainBody.Children.Add(usc);*/
        }
    }
}
