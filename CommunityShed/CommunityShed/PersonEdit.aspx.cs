using CommunityShed.Data;
using CommunityShed.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityShed
{
    public partial class PersonEdit : BasePage
    {
        int personId = 0;               //get personId
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Get personId of logged in user and check to see if it's valid */

            if (!IsPostBack)
            {
                personId = CustomUser.PersonId;
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Name, Email
                    from Person
                    where PersonId = @PersonId
                ", new SqlParameter("@PersonId", personId));

                if (dt.Rows.Count == 1)
                {
                    NameTextBox.Text = dt.Rows[0].Field<string>("Name");
                    EmailTextBox.Text = dt.Rows[0].Field<string>("Email");
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void EditPersonSubmit_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;

            DatabaseHelper.Update(@"
                update Person set
                    Name=@Name,
                    Email=@Email
                where PersonId=@PersonId
            ",
                new SqlParameter("@Name", name),
                new SqlParameter("@Email", email),
                new SqlParameter("@PersonId", personId /*Get Person Id*/));

            Response.Redirect("~/Default.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}