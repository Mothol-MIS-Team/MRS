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

namespace MRS_Store.Views.POS.POSControls
{
    /// <summary>
    /// Interaction logic for Totals.xaml
    /// </summary>
    public partial class Totals : UserControl
    {
        public Totals()
        {
            InitializeComponent();
        }
        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Close();*/
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            //Invoice Invoice = new Invoice();
            //Invoice.Show();
        }
    }
}
