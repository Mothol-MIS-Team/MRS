using MRS_Store.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MRS_Store.Globals
{
    public class Session
    {
        #region Define as Singleton
        private static Session _instance;

        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Session();
                }
                return (_instance);
            }
        }
        private Session()
        {


        }
        #endregion
        public User User { get; set; }
        public MainWindow mainWindow { get; set; }

        public void SetNextView(UserControl userControlView)
        {
            PreviousView = mainWindow.MainBody.Children;
            mainWindow.MainBody.Children.Clear();
            mainWindow.MainBody.Children.Add(userControlView);
        }
        public void SetPreviousView()
        {
            mainWindow.MainBody.Children.Clear();
            foreach (UserControl item in previousView)
            {
                mainWindow.MainBody.Children.Add(item);

            }
        }
        private UIElementCollection previousView;
        public UIElementCollection PreviousView { get { return previousView; } set { previousView = value; } }

    }
}
