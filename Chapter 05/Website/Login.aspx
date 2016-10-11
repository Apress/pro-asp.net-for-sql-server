<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_aspx" Title="Login" %>
<%@ Register Src="Controls/LoginControls.ascx" TagName="LoginControls" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

    <uc1:LoginControls ID="LoginControls1" runat="server" />

</asp:Content>
