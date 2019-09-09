using CommunityShed.Data;
using CommunityShed.State;
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
    public partial class CommunityEdit : BasePage
    {
        int? communityId = null;

        protected void Page_Init(object sender, EventArgs e)
        {
            communityId = CommunityState.GetActiveCommunityId();
            if (communityId == null)
            {
                Response.Redirect("~/MyCommunities.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int personId = CustomUser.PersonId;

                // Filtering by the Community.CreatePersonId column
                // here to ensure that the current user is the owner
                // of the community.
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select CommunityName, IsOpen
                    from Community
                    where CommunityId = @CommunityId and CreatorPersonId = @CreatorPersonId
                ",
                    new SqlParameter("@CommunityId", communityId.Value),
                    new SqlParameter("@CreatorPersonId", personId));

                if (dt.Rows.Count == 0)
                {
                    Response.Redirect("~/Community.aspx");
                }

                CommunityNameTextBox.Text = dt.Rows[0].Field<string>("CommunityName");
                CommunityIsAvailableCheckBox.Checked = dt.Rows[0].Field<bool>("IsOpen");
            }
        }

        protected void EditCommunitySubmit_Click(object sender, EventArgs e)
        {
            string communityName = CommunityNameTextBox.Text;
            bool isOpen = CommunityIsAvailableCheckBox.Checked;

            int personId = CustomUser.PersonId;

            if (communityId != null)
            {
                // Filtering by the Community.CreatePersonId column
                // here to ensure that the current user is the owner
                // of the community.
                DatabaseHelper.Update(@"
                    update Community set
                        CommunityName = @CommunityName,
                        IsOpen = @IsOpen
                    where CommunityId = @CommunityId and CreatorPersonId = @CreatorPersonId
                ",
                    new SqlParameter("@CommunityName", communityName),
                    new SqlParameter("@IsOpen", isOpen),
                    new SqlParameter("@CommunityId", communityId.Value),
                    new SqlParameter("@CreatorPersonId", personId));
            }

            Response.Redirect("~/Community.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Community.aspx");
        }
    }
}