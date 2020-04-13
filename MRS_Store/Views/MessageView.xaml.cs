using MRS_Store.Globals;
using MRS_Store.Views;
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

namespace MRS_Store.Views
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : UserControl
    {
        public MessageView(string _message)
        {
            Message = _message;
            InitializeComponent();
        }
        string message;
        public string Message { get { return message; } set {message = value; } }
        private void Gotoview(object sender, RoutedEventArgs e)
        {
            Session.Instance.SetNextView(new DashboardView());
        }
    }
}
