<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductListing.aspx.cs" Inherits="ProductListing" Title="Product Listing" %>

<%@ Register Src="Controls/ProductListControl.ascx" TagName="ProductListControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ProductListControl ID="ProductListControl1" runat="server" />
</asp:Content>

