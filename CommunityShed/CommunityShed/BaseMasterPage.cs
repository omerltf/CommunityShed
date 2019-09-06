using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShed
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {
        public BasePage CustomPage
        {
            get
            {
                return (BasePage)Page;
            }
        }
    }
}