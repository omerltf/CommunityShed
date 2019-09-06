using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityShed.Data;
using System.Data;
using System.Data.SqlClient;

namespace CommunityShed
{
    public partial class PersonAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddPersonSubmit_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string enteredPassword = PasswordTextBox.Text;

            int? id = DatabaseHelper.Insert(@"
                insert into Person (Name, Email, Password)
                values (@Name, @Email, @Password);
            ", new SqlParameter("@Name", name),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", enteredPassword));

            Response.Redirect("~/Default.aspx");
        }
    }
}