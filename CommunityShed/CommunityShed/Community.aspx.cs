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
    public partial class Community : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int? currentCommunityId = CommunityState.GetActiveCommunity();
                if (currentCommunityId != null)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select ToolName, ToolId
                    from Tool
                    where CommunityId=@CommunityId
                ", new SqlParameter("@CommunityId", currentCommunityId));
                    if (dt.Rows.Count != 0)
                    {
                        ToolsRepeater.DataSource = dt.Rows;
                        ToolsRepeater.DataBind();
                    }
                }
            }
        }

        protected void BorrowToolButton_Click(object sender, EventArgs e)
        {

        }

        protected void SearchSubmitButton_Click(object sender, EventArgs e)
        {
            string searchString = SearchBoxTextBox.Text;
            int? currentCommunityId = CommunityState.GetActiveCommunity();
            if (currentCommunityId != null)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select ToolName, ToolId
                    from Tool
                    where CommunityId=@CommunityId and (
                        ToolName like '%' + @SearchString + '%' or
                        Purpose like '%' + @SearchString + '%' or
                        Age like '%' + @SearchString + '%'
                    )
                ", new SqlParameter("@CommunityId", currentCommunityId),
                   new SqlParameter("@SearchString", searchString));
                if (dt.Rows.Count > 0)
                {
                    ToolsRepeater.DataSource = dt.Rows;
                }
                else
                {
                    ToolsRepeater.DataSource = null;
                }
                ToolsRepeater.DataBind();
            }

        }
    }
}