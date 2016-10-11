<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="_Product" Title="Product Page" %>
<%@ Register Src="Controls/ProductPhoto.ascx" TagName="ProductPhoto" TagPrefix="uc1" %>
<%@ Register Src="Controls/ProductDetail.ascx" TagName="ProductDetail" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table>
<tr>
<td style="vertical-align: top;">
    <uc1:ProductPhoto ID="ProductPhoto1" runat="server" />
</td>
<td style="vertical-align: top;">
    <uc2:ProductDetail ID="ProductDetail1" runat="server" />
</td>
</tr>
</table>
</asp:Content>
