using CommunityShed.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityShed
{
    public partial class CommunityAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCommunitySubmit_Click(object sender, EventArgs e)
        {
            string communityName = CommunityNameTextBox.Text;
            bool isOpen = CommunityIsAvailableCheckBox.Checked;
            //get CreatorPersonId from the current logged in person's Id

            int? id = DatabaseHelper.Insert(@"
                insert into Community (CommunityName, IsOpen, CreatorPersonId)
                values (@CommunityName, @IsOpen, @CreatorPersonId);
            ", new SqlParameter("@CommunityName", communityName),
                new SqlParameter("@IsOpen", isOpen),
                new SqlParameter("@CreatorPersonId", 1));

            Response.Redirect("~/Default.aspx");
        }
    }
}