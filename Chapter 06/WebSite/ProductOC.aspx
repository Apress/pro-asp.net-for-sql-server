<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductOC.aspx.cs" Inherits="ProductOC" Title="Product (Output Cache)" %>
<%@ OutputCache Duration="60" VaryByParam="*" %>
<%@ Register Src="Controls/ProductPhotoOC.ascx" TagName="ProductPhotoOC" TagPrefix="uc1" %>
<%@ Register Src="Controls/ProductDetailOC.ascx" TagName="ProductDetailOC" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr>
<td style="vertical-align: top;">
    <uc1:ProductPhotoOC ID="ProductPhotoOC1" runat="server" />
</td>
<td style="vertical-align: top;">
    <uc2:ProductDetailOC ID="ProductDetailOC1" runat="server" />
</td>
</tr>
</table>
</asp:Content>
