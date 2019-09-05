<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CommunityEdit.aspx.cs" Inherits="CommunityShed.CommunityEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Edit Community</h2>

    <div>

        <div class="form-group p-3 col-8">
            <asp:Label ID="CommunityNameLabel" Text="Community Name: " runat="server" AssociatedControlID="CommunityNameTextBox" />
            <asp:TextBox ID="CommunityNameTextBox" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group p-3">
            <asp:Label CssClass="form-check-label" ID="CommunityIsAvailableCheckBoxLabel" Text="Is Available? " runat="server" AssociatedControlID="CommunityIsAvailableCheckBox" />
            <div class="form-group p-3">
                <asp:CheckBox CssClass="form-check-input" ID="CommunityIsAvailableCheckBox" Checked="false" runat="server" />
            </div>
        </div>

        <div class="p-3" style="float: right;">
            <asp:Button CssClass="btn btn-danger" ID="EditCommunitySubmit" Text="Submit Changes" runat="server" OnClick="EditCommunitySubmit_Click" />
        </div>

        <div class="p-3" style="float: left;">
            <asp:Button CssClass="btn btn-warning" ID="CancelButton" Text="Cancel Changes" runat="server" OnClick="CancelButton_Click" /> 
        </div>
    </div>

</asp:Content>
