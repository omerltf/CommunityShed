using CommunityShed.Data;
using CommunityShed.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

                string currentUserEmail = ticket.Name;

                DataTable currentUserInformationDataTable = 
                    DatabaseHelper.Retrieve(@"
                        select p.Name, pc.CommunityId, r.RoleName, p.PersonId
                        from Person p
                        join PersonCommunity pc on pc.PersonId = p.PersonId
                        join PersonCommunityRole pcr on pcr.PersonCommunityId = pc.PersonCommunityId
                        join Role r on r.RoleId = pcr.RoleId
                        where p.Email = @Email
                        order by CommunityId, RoleName
                    ",
                        new SqlParameter("@Email", currentUserEmail));

                if (currentUserInformationDataTable.Rows.Count == 0)
                {
                    throw new ApplicationException($"Problem encountered retrieving user information for email: {currentUserEmail}");
                }

                CustomPrincipal principal = new CustomPrincipal(
                    customIdentity, currentUserInformationDataTable);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}