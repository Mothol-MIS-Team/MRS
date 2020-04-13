using MRS_Store.Globals;
using MRS_Store.Views;
using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace MRS_Store.Auth
{
    class CustomPrincipalPermission 
    {
        #region Define as Singleton
        private static CustomPrincipalPermission _instance;

        public static CustomPrincipalPermission Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomPrincipalPermission();
                }
                return (_instance);
            }
        }
        private CustomPrincipalPermission()
        {
        }
        public bool Demand(string RoleName)
        {
            try
            {
                PrincipalPermission MyPermission = new PrincipalPermission(Thread.CurrentPrincipal.Identity.Name, RoleName);
                MyPermission.Demand();
                return true;
            }
            catch (SecurityException e)
            {

                Session.Instance.SetNextView(new MessageView(e.Message));
                return false;
            }
            
        }

        #endregion
    }
}
