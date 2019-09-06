<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommunitySearch.aspx.cs" Inherits="CommunityShed.CommunitySearch" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2>Communities List</h2>

    <asp:Repeater ID="CommunitySearchRepeater" runat="server" ItemType="DataRow">
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
                <td> <asp:Button ID="JoinCommunityButton" CssClass="btn btn-dark" OnClick="JoinCommunityButton_Click" CommandArgument='<%# Item.Field<int>("CommunityId") %>' Text="Join Community" runat="server" /> </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:HyperLink ID="HomeHyperLink" runat="server" NavigateUrl="~/MyCommunities.aspx" Text="Back" CssClass="btn btn-link" />
</asp:Content>
