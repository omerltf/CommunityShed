using CommunityShed.Data;
using CommunityShed.Security;
using CommunityShed.State;
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

            int personId = CustomUser.PersonId;

            int communityId = DatabaseHelper.ExecuteScalar<int>(@"
                begin tran;

                insert into Community (CommunityName, IsOpen, CreatorPersonId)
                values (@CommunityName, @IsOpen, @PersonId);

                declare @CommunityId int;
                set @CommunityId = cast(scope_identity() as int);

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
                    3 -- Approver
                );

                insert into PersonCommunityRole (
                    PersonCommunityId,
                    RoleId
                ) values (
                    @PersonCommunityId,
                    4 -- Reviewer
                );

                insert into PersonCommunityRole (
                    PersonCommunityId,
                    RoleId
                ) values (
                    @PersonCommunityId,
                    5 -- Enforcer
                );

                commit tran;

                select @CommunityId;
            ", 
                new SqlParameter("@CommunityName", communityName),
                new SqlParameter("@IsOpen", isOpen),
                new SqlParameter("@PersonId", personId));

            CommunityState.SetActiveCommunity(communityId, personId);

            Response.Redirect("~/Community.aspx");
        }
    }
}