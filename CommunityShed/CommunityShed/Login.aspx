<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommunityShed.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <asp:ValidationSummary runat="server" />

    <div>
        <asp:Label ID="EmailLabel" runat="server" Text="Email: " AssociatedControlID="EmailTextBox" />
        <asp:TextBox ID="EmailTextBox" runat="server" />
        <asp:RequiredFieldValidator runat="server" 
            ControlToValidate="EmailTextBox"
            Display="Dynamic" 
            ErrorMessage="Please provide an email address."
            Text="*" />
    </div>

    <div>
        <asp:Label ID="PasswordLabel" runat="server" Text="Password: " AssociatedControlID="PasswordTextBox" />
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" />
        <asp:RequiredFieldValidator runat="server" 
            ControlToValidate="PasswordTextBox"
            Display="Dynamic" 
            ErrorMessage="Please provide a password."
            Text="*" />
    </div>

    <div>
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    </div>

</asp:Content>
