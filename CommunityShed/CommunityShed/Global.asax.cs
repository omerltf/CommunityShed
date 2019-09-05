using CommunityShed.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace CommunityShed
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.4.1.min.js",
                    DebugPath = "~/Scripts/jquery-3.4.1.js"
                });
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);

                // TODO Get user information including roles from the database
                string[] roles = {};

                CustomPrincipal principal = new CustomPrincipal(customIdentity, roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}