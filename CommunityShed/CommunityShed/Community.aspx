<%@ Page Title="Community" Language="C#" MasterPageFile="~/Community.Master" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="CommunityShed.Community" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="main" runat="server">

    <h1>Tools</h1>

    <fieldset>
        <legend>Search</legend>
    <div>
        <asp:Label ID="SearchBoxLabel" Text="Search Tools (by name): " runat="server" AssociatedControlID="SearchBoxTextBox" />
        <asp:TextBox ID="SearchBoxTextBox" runat="server" />
        <asp:Button ID="SearchSubmitButton" runat="server" CssClass="btn btn-success" Text="Search" OnClick="SearchSubmitButton_Click" />
    </div>
        </fieldset>

    <asp:Repeater ID="ToolsRepeater" ItemType="DataRow" runat="server" >
        <HeaderTemplate>
            <table class="table table-sm table-striped table-hover">
                <thead class="thead-dark">
                    <tr>
                        <th>Tool Name</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Item.Field<string>("ToolName")%></td>
                <td> <asp:Button runat="server" ID="BorrowToolButton" OnClick="BorrowToolButton_Click" CssClass="btn btn-secondary btn-sm" CommandArgument='<%# Item.Field<int>("ToolId")%>' Text="Borrow Tool" /> </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>

        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
