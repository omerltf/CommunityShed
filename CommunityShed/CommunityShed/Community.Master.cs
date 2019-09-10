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
        State.Community community = null;

        protected void Page_Init(object sender, EventArgs e)
        {
            community = CommunityState.GetActiveCommunity();
            if (community == null)
            {
                Response.Redirect("~/MyCommunities.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommunityNameLabel.Text = community.CommunityName;
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
            if (personId == community.CreatorPersonId)
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