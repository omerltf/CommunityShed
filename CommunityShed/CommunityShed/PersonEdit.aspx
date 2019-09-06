<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonEdit.aspx.cs" Inherits="CommunityShed.PersonEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Edit Profile</h2>

    <div>

        <div class="form-group p-3 col-8">
            <asp:Label ID="NameLabel" Text="Name: " runat="server" AssociatedControlID="NameTextBox" />
            <asp:TextBox ID="NameTextBox" CssClass="form-control" runat="server" />
        </div>

        <div class="row p-3">

            <div class="form-group col p-3">
                <asp:Label ID="EmailLabel" Text="Email: " runat="server" AssociatedControlID="EmailTextBox" />
                <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" />
            </div>

        </div>

        <div class="p-3" style="float: right;">
            <asp:Button CssClass="btn btn-danger" ID="EditPersonSubmit" Text="Make Changes" runat="server" OnClick="EditPersonSubmit_Click" />
        </div>

        <div class="p-3" style="float: left;">
            <asp:Button CssClass="btn btn-warning" ID="CancelButton" Text="Cancel Changes" runat="server" OnClick="CancelButton_Click" />
        </div>
    </div>
</asp:Content>
