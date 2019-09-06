using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityShed
{
    public partial class Site : BaseMasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            navbarNav.Visible = Request.IsAuthenticated;
            UserInformation.Visible = Request.IsAuthenticated;
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}