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

namespace CommunityShed
{
    public partial class MyCommunities : BasePage
    {
        int personId = 0;               //get personId
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/NotAuthorized,aspx");
            }
            if (!IsPostBack)
            {
                CustomPrincipal user = (CustomPrincipal)Page.User;
                personId = user.PersonId;
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
    }
}