using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}