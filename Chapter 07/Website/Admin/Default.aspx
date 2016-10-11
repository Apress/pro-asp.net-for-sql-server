<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" Title="Favorite Link: Admin" %>

<%@ Register Src="ManagerControls/ManagerControl.ascx" TagName="ManagerControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <uc1:ManagerControl ID="ManagerControl1" runat="server" />
</asp:Content>
