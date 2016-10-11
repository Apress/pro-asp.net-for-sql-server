<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="CMSPageList.aspx.cs" Inherits="Admin_CMSPageList" Title="CMS Pages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1>All CMS Pages</h1>
<a href='<%=Page.ResolveUrl("~/view/newpage.aspx") %>'>New</a>
<subsonic:QuickTable ID=elQuick runat=server TableName="CMS_Page" ColumnList="PageID:ID,Title,PageURL:Url" LinkToPage="cmspagelist.aspx" LinkOnColumn="pageurl" />
</asp:Content>

