<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ProductPF.aspx.cs" Inherits="ProductPF" Title="Product (Page Fragment)" %>
<%@ Register Src="Controls/ProductPhotoPF.ascx" TagName="ProductPhotoPF" TagPrefix="uc1" %>
<%@ Register Src="Controls/ProductDetailPF.ascx" TagName="ProductDetailPF" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr>
<td style="vertical-align: top;">
    <uc1:ProductPhotoPF ID="ProductPhotoPF1" runat="server" />
</td>
<td style="vertical-align: top;">
    <uc2:ProductDetailPF ID="ProductDetailPF1" runat="server" />
</td>
</tr>
</table>
</asp:Content>
