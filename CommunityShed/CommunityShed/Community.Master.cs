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
        int? communityId = null;
        int? creatorPersonId = null;

        protected void Page_Init(object sender, EventArgs e)
        {
            communityId = CommunityState.GetActiveCommunity();
            if (communityId == null)
            {
                Response.Redirect("~/MyCommunities.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int personId = CustomPage.CustomUser.PersonId;

                DataTable communityDataTable = DatabaseHelper.Retrieve(@"
                    select c.CommunityName, c.CreatorPersonId
                    from Community c
                    join PersonCommunity pc on pc.CommunityId = c.CommunityId
                    where c.CommunityId = @CommunityId and pc.PersonId = @PersonId
                ",
                    new SqlParameter("@CommunityId", communityId.Value),
                    new SqlParameter("@PersonId", personId));

                if (communityDataTable.Rows.Count == 0)
                {
                    Response.Redirect("~/MyCommunities.aspx");
                }

                creatorPersonId = communityDataTable.Rows[0].Field<int?>("CreatorPersonId");

                string communityName = communityDataTable.Rows[0].Field<string>("CommunityName");

                CommunityNameLabel.Text = communityName;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            RenderLeftNav();
        }

        private void RenderLeftNav()
        {
            int personId = CustomPage.CustomUser.PersonId;

            AddNavLink("Available Tools", "Community.aspx");
            AddNavLink("Borrowed Tools", "BorrowedTools.aspx");
            AddNavLink("My Tools", "MyTools.aspx");
            AddNavLink("Add Tool", "ToolAdd.aspx");

            if (CustomPage.CustomUser.IsInRole("Approver"))
            {
                AddNavLink("Approve Members", "ApproveMembers.aspx");
            }

            if (CustomPage.CustomUser.IsInRole("Reviewer"))
            {
                AddNavLink("Review Disputes", "ReviewDisputes.aspx");
            }

            if (CustomPage.CustomUser.IsInRole("Enforcer"))
            {
                AddNavLink("Members", "CommunityMembers.aspx");
            }

            // If the current user is the creator of this community
            // then add an "Edit Community" link.
            if (personId == creatorPersonId.Value)
            {
                AddNavLink("Edit Community", "CommunityEdit.aspx");
            }
        }

        private void AddNavLink(string text, string pageName)
        {
            var hyperLink = new HyperLink();
            hyperLink.Text = text;
            hyperLink.NavigateUrl = $"~/{pageName}";
            hyperLink.CssClass = $"list-group-item list-group-item-secondary list-group-item-action {(Request.RawUrl.Contains(pageName) ? "active" : string.Empty)}";
            LeftNav.Controls.Add(hyperLink);
        }
    }
}