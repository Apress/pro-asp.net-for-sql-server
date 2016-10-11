<%@ Page Language="C#" MasterPageFile="~/Chapter01.master" AutoEventWireup="true" CodeFile="Tools.aspx.cs" Inherits="Tools" Title="Chapter 1: Tools" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">

javascript:location.href='http://linkminder.smallsharptools.com/AddLink.ashx?action=add&amp;address='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title)

javascript:x=document;a=encodeURIComponent(x.location.href);t=encodeURIComponent(x.title);d=encodeURIComponent(window.getSelection());open('http://linkminder.smallsharptools.com/AddLink.ashx?action=add&amp;popup=1&amp;address='+a+'&amp;title='+t+'&amp;description='+d,'Scuttle','modal=1,status=0,scrollbars=1,toolbar=0,resizable=1,width=730,height=465,left='+(screen.width-730)/2+',top='+(screen.height-425)/2);void 0;

</asp:Content>

