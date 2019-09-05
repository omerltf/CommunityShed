<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommunityShed.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

    <asp:ValidationSummary runat="server" />

    <asp:CustomValidator ID="PasswordCheck" runat="server" 
        ErrorMessage="Login failed due to an incorrect email or password." 
        Display="None" 
        OnServerValidate="PasswordCheck_ServerValidate" />

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

    <div>
        <asp:HyperLink runat="server" NavigateUrl="~/PersonAdd.aspx" Text="Register" />
    </div>

</asp:Content>
