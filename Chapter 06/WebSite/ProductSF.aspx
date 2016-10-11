<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductSF.aspx.cs" Inherits="ProductSF" Title="Product (Substitution Fragment)" %>

<%@ OutputCache Duration="60" VaryByParam="*" %>
<%@ Register Src="Controls/ProductPhotoOC.ascx" TagName="ProductPhotoOC" TagPrefix="uc1" %>
<%@ Register Src="Controls/ProductDetailSFBridge.ascx" TagName="ProductDetailSFBridge"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr>
<td style="vertical-align: top;">
    <uc1:ProductPhotoOC ID="ProductPhotoOC1" runat="server" />
</td>
<td style="vertical-align: top;">
    <uc2:ProductDetailSFBridge ID="ProductDetailSFBridge1" runat="server" />
</td>
</tr>
</table>
</asp:Content>
