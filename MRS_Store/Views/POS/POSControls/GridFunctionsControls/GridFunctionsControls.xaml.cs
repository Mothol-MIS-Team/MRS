using MRS_Store.Views.Products;
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

namespace MRS_Store.Views.POS.POSControls.GridFunctionsControls
{
    /// <summary>
    /// Interaction logic for GridFunctionsControls.xaml
    /// </summary>
    public partial class GridFunctionsControls : UserControl
    {
        public GridFunctionsControls()
        {
            InitializeComponent();
        }

        private void ListViewFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc;
            DependencyObject parentControl = this.Parent;

            while (!(parentControl is UserControl))
            {
                parentControl = LogicalTreeHelper.GetParent(parentControl);
            }
            UserControl parentUserControl = (UserControl)parentControl;
            POSView pOSView = (POSView)parentUserControl;
            pOSView.GridFunctions.Children.Clear();
            usc = ((ListViewItem)((ListView)sender).SelectedItem).Name switch
            {
                "AddProduct" => new ProductList(),
                _ => new GridFunctionsControls(),
            };
            pOSView.GridFunctions.Children.Add(usc);
        }
    }
}
