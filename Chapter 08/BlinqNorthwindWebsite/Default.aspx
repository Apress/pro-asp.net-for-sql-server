<%@ Page MasterPageFile="~/MasterPage.master" Title="Northwind" Language="C#" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">  
<h1>Northwind</h1>
<div>
    <asp:BulletedList runat="server" ID="links" DataSourceID="dsSiteMap" DisplayMode="HyperLink" DataTextField="title" DataValueField="url" />
    <asp:SiteMapDataSource runat="server" ID="dsSiteMap" ShowStartingNode="false" />
</div>
</asp:Content>