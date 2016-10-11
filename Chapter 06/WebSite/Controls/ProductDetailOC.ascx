<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDetailOC.ascx.cs" Inherits="Controls_ProductDetailOC" %>

<asp:Label ID="lblProductName" runat="server" Text=""></asp:Label><br />
<asp:Label ID="lblProductNumber" runat="server" Text=""></asp:Label><br />
<asp:Substitution ID="subPrice" runat="server" 
    MethodName="GetPrice" /><br />
<asp:Substitution ID="subAvailability" runat="server" 
    MethodName="GetAvailability" /><br />
