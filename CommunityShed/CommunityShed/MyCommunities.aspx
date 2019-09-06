<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCommunities.aspx.cs" Inherits="CommunityShed.MyCommunities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="CommunitiesRepeater" runat="server" >
        <HeaderTemplate>
            <table class="table table-sm table-striped table-hover">
                <thead class="thead-dark">
                    <tr>
                        <th>Community Name</th>
                        <th>Community Type</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
    </asp:Repeater>

</asp:Content>
