<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true"
    CodeFile="AddLink.aspx.cs" Inherits="AddLink_aspx" Title="Favorite Link: Add Link" %>

<%@ Register Src="~/Controls/LinkEditControl.ascx" TagName="LinkEditControl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    
    <uc1:LinkEditControl ID="LinkEditControl1" runat="server" OnSaved="LinkEditControl1_Saved" />
    
</asp:Content>
