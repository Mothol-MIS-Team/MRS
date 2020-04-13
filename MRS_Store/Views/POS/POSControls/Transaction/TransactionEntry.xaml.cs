using MRS_Store.Views.POS.POSControls.Transaction;
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
    /// Interaction logic for TransactionEntry.xaml
    /// </summary>
    public partial class TransactionEntry : UserControl
    {
        public TransactionEntry()
        {
            InitializeComponent();
            TransactionEntryGrid.Children.Add(new Entries());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);
            TransactionEntryGrid.Children.Clear();
            UserControl usc = index switch
            {
                0 => new Entries(),
                1 => new Payments(),
                _ => new Entries(),
            };
            TransactionEntryGrid.Children.Add(usc);
        }

    }
}
