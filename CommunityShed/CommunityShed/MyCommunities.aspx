<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCommunities.aspx.cs" Inherits="CommunityShed.MyCommunities" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>My Communities</h2>

    <asp:Repeater ID="CommunitiesRepeater" runat="server" ItemType="DataRow" >
        <HeaderTemplate>
            <table class="table table-sm table-striped table-hover">
                <thead class="thead-dark">
                    <tr>
                        <th>Community Name</th>
                        <th>Is Open Community?</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("CommunityName")%></td>
                <td><%# Item.Field<bool>("IsOpen") %></td>
                <td><asp:HyperLink runat="server" CssClass="btn btn-secondary btn-sm" NavigateUrl="~/Community.aspx" Text="Select" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <div>
        <asp:HyperLink ID="AddCommunityHyperLink" CssClass="btn btn-lg" runat="server" NavigateUrl="~/CommunityAdd.aspx" Text="Add New Community" />
        <asp:HyperLink ID="JoinCommunityHyperLink" CssClass="btn btn-lg" runat="server" NavigateUrl="~/CommunitySearch.aspx" Text="Join Existing Community" />
    </div>

    <div>
        <div>
        <asp:HyperLink runat="server" CssClass="btn btn-link" NavigateUrl="~/Default.aspx" Text="Home" />
    </div>
    </div>

</asp:Content>
