<%@ Page Title="" Language="C#" MasterPageFile="~/Customer Site/CustomerSite.Master" AutoEventWireup="true" CodeBehind="TrackPackage.aspx.cs" Inherits="IT191P_Project.Customer_Site.TrackPackage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title_bar" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_content" runat="server">
     <h1 class="page-header">Check Package Transactions</h1>
    <div class="form-group input-group col-lg-10">
        <asp:TextBox type="text" ID="txtSearch" CssClass="form-control" runat="server" placeholder="Search" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
        <span class="input-group-btn">
            <button class="btn btn-default" type="button"><i class="fa fa-search"></i></button>
        </span>
    </div>
    <div class="col-lg-12">

    </div>
</asp:Content>
