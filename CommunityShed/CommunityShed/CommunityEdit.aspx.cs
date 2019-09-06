using CommunityShed.Data;
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
        //int currentUserId = 0; //get current logged in user ID
        //int currentCommunityId = 0; //get communityId of community to be edited
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Get personId of logged in user and check to see if they have permission to edit this community */
            /* Maybe also need to get current communityId (or whichever community has permissions) to see which community to change*/

            //if (!IsPostBack)
            //{
            //    DataTable dropDownDataTable = DatabaseHelper.Retrieve(@"
            //        select CommunityName, CommunityId
            //        from Community
            //    ");
            //    CommunitiesDropDownList.DataTextField = "CommunityName";
            //    CommunitiesDropDownList.DataValueField = "CommunityId";
            //    CommunitiesDropDownList.AppendDataBoundItems = true;
            //    CommunitiesDropDownList.DataSource = dropDownDataTable.Rows;
            //    CommunitiesDropDownList.DataBind();

                


            //    DataTable dt = DatabaseHelper.Retrieve(@"
            //        select CommunityName, CreatorPersonId, IsOpen
            //        from Community
            //        where CommunityId=@CommunityId
            //    ", new SqlParameter("@CommunityId", currentCommunityId));

            //    if (dt.Rows.Count == 1)
            //    {
            //        CommunityNameTextBox.Text = dt.Rows[0].Field<string>("CommunityName");
            //        CommunityIsAvailableCheckBox.Enabled = dt.Rows[0].Field<bool>("IsOpen");
            //    }
            //    else
            //    {
            //        Response.Redirect("~/Default.aspx");
            //    }
            //}

        }

        protected void EditCommunitySubmit_Click(object sender, EventArgs e)
        {
            //string communityName = CommunityNameTextBox.Text;
            //bool isOpen = CommunityIsAvailableCheckBox.Checked;
            ///* get CreatorPersonId from the current logged in person's Id */
            ///* This query does not look right, see which Id to check against in the where statement */
            ///* 'where CreatorPersonId = @CreatorPersonId' could be changed to 'where CommunityId = @CommunityId' to use communityId to see which community to edit */
            //DatabaseHelper.Update(@"
            //    update Community set
            //        CommunityName=@CommunityName,
            //        IsOpen=@IsOpen
            //    where CreatorPersonId = @CreatorPersonId
            //",
            //    new SqlParameter("@CommunityName", communityName),
            //    new SqlParameter("@IsOpen", isOpen),
            //    new SqlParameter("@CreatorPersonId", currentUserId));

            //Response.Redirect("~/Default.aspx"); 
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /*protected void CommunitiesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCommunityId = int.Parse(CommunitiesDropDownList.SelectedValue);
        }*/
    }
}