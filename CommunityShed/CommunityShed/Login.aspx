<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommunityShed.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <div>
        <asp:Label ID="EmailLabel" runat="server" Text="Email: " AssociatedControlID="EmailTextBox" />
        <asp:TextBox ID="EmailTextBox" runat="server" />
    </div>

    <div>
        <asp:Label ID="PasswordLabel" runat="server" Text="Password: " AssociatedControlID="PasswordTextBox" />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" />
    </div>

    <div>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </div>

</asp:Content>
