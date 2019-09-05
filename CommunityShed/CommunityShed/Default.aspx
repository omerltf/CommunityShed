<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CommunityShed.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Home</h1>

    <asp:HyperLink ID="PersonAddHyperLink" runat="server" Text="Add Person" NavigateUrl="~/PersonAdd.aspx" />

</asp:Content>
