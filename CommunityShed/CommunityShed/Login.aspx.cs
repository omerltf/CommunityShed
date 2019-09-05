using CommunityShed.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityShed
{
    public partial class Login : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("~/NotAuthorized.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = EmailTextBox.Text;

                FormsAuthentication.RedirectFromLoginPage(email, false);
            }
        }

        protected void PasswordCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = EmailTextBox.Text;

            DataTable person = DatabaseHelper.Retrieve(@"
                select HashedPassword
                from Person
                where Email = @Email
            ", 
                new SqlParameter("@Email", email));

            if (person.Rows.Count == 1)
            {
                string password = PasswordTextBox.Text;

                if (BCrypt.Net.BCrypt.Verify(
                    password, person.Rows[0].Field<string>("HashedPassword")))
                {
                    args.IsValid = true;
                    return;
                }
            }

            args.IsValid = false;
        }
    }
}