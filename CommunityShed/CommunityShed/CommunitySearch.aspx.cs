using CommunityShed.Data;
using CommunityShed.Security;
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
    public partial class CommunitySearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int personId = CustomUser.PersonId;
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select * from Community where CommunityId not in (
	                select CommunityId from PersonCommunity
	                where PersonId = @PersonId
                )", new SqlParameter("@PersonId", personId));

                if (dt.Rows.Count > 0)
                {
                    CommunitySearchRepeater.DataSource = dt.Rows;
                    CommunitySearchRepeater.DataBind();
                }
            }
        }

        protected void JoinCommunityButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int communityId = int.Parse(button.CommandArgument);
            int personId = CustomUser.PersonId;

            DatabaseHelper.Execute(@"
            begin tran;

            insert into PersonCommunity (
                PersonId,
                CommunityId,
                PersonCommunityStatusId
            ) values (
                @PersonId,
                @CommunityId,
                2 -- Approved
            );

            declare @PersonCommunityId int;
            set @PersonCommunityId = cast(scope_identity() as int);

            insert into PersonCommunityRole (
                PersonCommunityId,
                RoleId
            ) values (
                @PersonCommunityId,
                2 -- Member
            );

            commit tran;
            ",
            new SqlParameter("@PersonId", personId),
            new SqlParameter("@CommunityId", communityId));

            CommunityState.SetActiveCommunity(communityId);

            Response.Redirect("~/Community.aspx");
        }
    }
}