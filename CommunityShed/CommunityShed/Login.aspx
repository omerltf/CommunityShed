<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CommunityShed.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h1>Login</h1>

    <div class="col-4">

        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />

        <asp:CustomValidator ID="PasswordCheck" runat="server" 
            ErrorMessage="Login failed due to an incorrect email or password." 
            Display="None" 
            OnServerValidate="PasswordCheck_ServerValidate" />

        <div class="form-group">
            <asp:Label ID="EmailLabel" runat="server" Text="Email: " AssociatedControlID="EmailTextBox" />
            <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" />
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="EmailTextBox"
                Display="Dynamic" 
                ErrorMessage="Please provide an email address."
                Text="*" />
        </div>

        <div class="form-group">
            <asp:Label ID="PasswordLabel" runat="server" Text="Password: " AssociatedControlID="PasswordTextBox" />
            <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" TextMode="Password" />
            <asp:RequiredFieldValidator runat="server" 
                ControlToValidate="PasswordTextBox"
                Display="Dynamic" 
                ErrorMessage="Please provide a password."
                Text="*" />
        </div>

        <div>
            <asp:Button ID="LoginButton" runat="server" 
                CssClass="btn btn-primary" Text="Login" OnClick="LoginButton_Click" />
            <asp:HyperLink runat="server" 
                CssClass="btn btn-outline-secondary"
                NavigateUrl="~/PersonAdd.aspx" Text="Register" />
        </div>

    </div>

</asp:Content>
