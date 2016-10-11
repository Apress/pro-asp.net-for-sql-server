<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="PageState_Default" Title="Page State Example" EnableViewState="false" %>

<%@ Register Src="Controls/TopUserControl.ascx" TagName="TopUserControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    TextBox: 
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Do PostBack" />
    <br />
    <uc1:TopUserControl ID="TopUserControl1" runat="server" />
</asp:Content>
