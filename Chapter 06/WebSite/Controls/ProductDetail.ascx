<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.ascx.cs" Inherits="Controls_ProductDetail" %>

<asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
<br />
<asp:Substitution ID="subPrice" runat="server" 
    MethodName="GetPrice" />
<br />
<asp:Substitution ID="subAvailability" runat="server" 
    MethodName="GetAvailability" />
