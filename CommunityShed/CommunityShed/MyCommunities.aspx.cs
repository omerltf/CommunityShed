using CommunityShed.Data;
using CommunityShed.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CommunityShed.State;

namespace CommunityShed
{
    public partial class MyCommunities : BasePage
    {
        int personId = 0;               //get personId
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                personId = CustomUser.PersonId;
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select pc.CommunityId, pc.PersonCommunityStatusId, c.CommunityName, c.IsOpen
                    from PersonCommunity pc
                    join Community c on c.CommunityId=pc.CommunityId
                    where pc.PersonId=@PersonId
                ", new SqlParameter("@PersonId", personId));

                if (dt.Rows.Count > 0)
                {
                    CommunitiesRepeater.DataSource = dt.Rows;
                    CommunitiesRepeater.DataBind();
                }
            }
        }

        protected void SelectButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int communityId = int.Parse(button.CommandArgument);
            int personId = CustomUser.PersonId;
            CommunityState.SetActiveCommunity(communityId, personId);
            Response.Redirect("~/Community.aspx");
        }
    }
}