using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace MRS_Store.Views.Main.Controls
{
    /// <summary>
    /// Interaction logic for Header.xaml
    /// </summary>
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
            GetMachineInfo();
        }
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void GetMachineInfo()
        {
            String machineInfo = "";
            machineInfo +="Machine Name: " + Environment.MachineName + " \n";
            machineInfo +="User Name: " + Environment.UserName + " \n";
            machineInfo +="User Domain Name: " + Environment.UserDomainName + " \n";
            machineInfo +="OS Version: " + Environment.OSVersion.ToString() + " \n";
            machineInfo +="Is 64 Bit Operating System: " + Environment.Is64BitOperatingSystem + " \n";
            machineInfo +="Processor Count: " + Environment.ProcessorCount + " \n";
            machineInfo +="Is 64 Bit Process: " + Environment.Is64BitProcess + " \n" ;
            txtMachineInfo.Text = machineInfo;
        }

        private void SwitchLanguage(object sender, RoutedEventArgs e)
        {
        }
    }
}
