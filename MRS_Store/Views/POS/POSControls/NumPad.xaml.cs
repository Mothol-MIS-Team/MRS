using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace MRS_Store.Views.POS.Controls
{
    /// <summary>
    /// Interaction logic for NumPad.xaml
    /// </summary>
    public partial class NumPad : UserControl
    {
        public NumPad()
        {
            InitializeComponent();
        }

        private void OnScreenKeyboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string windir = Environment.GetEnvironmentVariable("WINDIR");
                string osk = null;

                if (osk == null)
                {
                    osk = Path.Combine(Path.Combine(windir, "sysnative"), "osk.exe");
                    if (!File.Exists(osk))
                    {
                        osk = null;
                    }
                }

                if (osk == null)
                {
                    osk = Path.Combine(Path.Combine(windir, "system32"), "osk.exe");
                    if (!File.Exists(osk))
                    {
                        osk = null;
                    }
                }

                if (osk == null)
                {
                    osk = "osk.exe";
                }
                ProcessStartInfo info = new ProcessStartInfo(osk);
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
                txtInput.Focus();
            }
            
            catch (Exception)
            {

                
            }
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text += ((Button)sender).Content;
        }

        private void btnEraser_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInput.Text))
            {
                if (!string.IsNullOrEmpty(txtInput.SelectedText))
                {
                     txtInput.Text = txtInput.Text.Remove(txtInput.SelectionStart , txtInput.SelectedText.Length);
                }
                else
                txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1, 1);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtInput.Text, out n);
        }
        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
