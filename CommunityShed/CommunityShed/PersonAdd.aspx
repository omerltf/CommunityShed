<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonAdd.aspx.cs" Inherits="CommunityShed.PersonAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div>
            <asp:Label ID="NameLabel" Text="Name: " runat="server" AssociatedControlID="NameTextBox" />
            <asp:TextBox ID="NameTextBox" runat="server" />
        </div>

        <div>
            <asp:Label ID="EmailLabel" Text="Email: " runat="server" AssociatedControlID="EmailTextBox" />
            <asp:TextBox ID="EmailTextBox" runat="server" />
        </div>

        <div>
            <asp:Label ID="PasswordLabel" Text="Password: " runat="server" AssociatedControlID="PasswordTextBox" />
            <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server" />
        </div>

        <div>
            <asp:Button ID="AddPersonSubmit" Text="Submit" runat="server" OnClick="AddPersonSubmit_Click" />
        </div>
    </div>
</asp:Content>
