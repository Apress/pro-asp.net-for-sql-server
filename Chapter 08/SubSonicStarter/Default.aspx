<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Welcome!" %>
<%@ Register Src="Modules/ContentManager/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Welcome!</h1>
    <cms:Paragraph ID=defaultTop runat=server ContentName=default_welcome />
</asp:Content>

