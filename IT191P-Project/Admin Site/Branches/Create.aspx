<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Site/Admin.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="IT191P_Project.Admin_Site.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_bar" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
    <h1 class="page-header">Create Users</h1>

    <h3 class="page-header">Personal Information</h3>
    <label>Location</label>
    <asp:TextBox type="text" placeholder="Location" ID="txtLocation" CssClass="form-control" runat="server"></asp:TextBox>

    <label>Branch Owner</label>
    <br />
    <asp:DropDownList ID="ddlBranchOwner" runat="server" DataSourceID="BranchOwnerDataSource" DataTextField="Column1" DataValueField="ID"></asp:DropDownList>
        <asp:SqlDataSource ID="BranchOwnerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ZoomDB %>" SelectCommand="SELECT [USER].[ID], [USER].LNAME + ', ' + [USER].FNAME + ' ' + [USER].MNAME 
            FROM [USER]
            WHERE [USER].USERTYPE = 'Branch Owner'">
        </asp:SqlDataSource>

    <br />
    <asp:Button ID="btnAdd" CssClass="btn btn-success btn-block" Text="Add Branch" runat="server" OnClick="btnAdd_Click" />
    <br />
    <asp:Button ID="btnClear" CssClass="btn btn-danger btn-block" Text="Clear" runat="server" OnClick="btnClear_Click" />

</asp:Content>
