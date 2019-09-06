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
    public partial class CommunityMaster : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // TODO Remove this after the active community is properly being set!!!
                CommunityState.SetActiveCommunity(1);

                int? communityId = CommunityState.GetActiveCommunity();
                if (communityId != null)
                {
                    int personId = CustomPage.CustomUser.PersonId;

                    DataTable communityDataTable = DatabaseHelper.Retrieve(@"
                    select c.CommunityName
                    from Community c
                    join PersonCommunity pc on pc.CommunityId = c.CommunityId
                    where c.CommunityId = @CommunityId and pc.PersonId = @PersonId
                ",
                        new SqlParameter("@CommunityId", communityId.Value),
                        new SqlParameter("@PersonId", personId));

                    if (communityDataTable.Rows.Count == 1)
                    {
                        string communityName = communityDataTable.Rows[0].Field<string>("CommunityName");

                        CommunityNameLabel.Text = communityName;

                        return;
                    }
                }

                Response.Redirect("~/MyCommunities.aspx");
            }
        }
    }
}