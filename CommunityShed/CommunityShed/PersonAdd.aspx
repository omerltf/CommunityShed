﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonAdd.aspx.cs" Inherits="CommunityShed.PersonAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group p-3 col-8">
        <asp:Label ID="NameLabel" Text="Name: " runat="server" AssociatedControlID="NameTextBox" />
        <asp:TextBox ID="NameTextBox" CssClass="form-control" runat="server" />
    </div>

    <div class="row p-3">

        <div class="form-group col p-3">
            <asp:Label ID="EmailLabel" Text="Email: " runat="server" AssociatedControlID="EmailTextBox" />
            <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group col p-3">
            <asp:Label ID="PasswordLabel" Text="Password: " runat="server" AssociatedControlID="PasswordTextBox" />
            <asp:TextBox ID="PasswordTextBox" CssClass="form-control" TextMode="Password" runat="server" />
        </div>
    </div>

    <div class="p-3" style="float: right;">
        <asp:Button CssClass="btn btn-primary" ID="AddPersonSubmit" Text="Submit" runat="server" OnClick="AddPersonSubmit_Click" />
    </div>

    <div>
        <asp:HyperLink runat="server" NavigateUrl="~/Login.aspx" Text="Login" />
    </div>

</asp:Content>
