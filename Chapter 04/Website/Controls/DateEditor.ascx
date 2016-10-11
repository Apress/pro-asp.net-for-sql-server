<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateEditor.ascx.cs" Inherits="DateEditor" %>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:CustomValidator ID="cvDate"
    runat="server" ControlToValidate="TextBox1" Display="Dynamic" EnableClientScript="False"
    ErrorMessage="Date is invalid" OnServerValidate="cvDate_ServerValidate">*</asp:CustomValidator><asp:RegularExpressionValidator
    ID="revDate" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Date format is invalid.  [MM/dd/yyyy]"
    ValidationExpression="^\d\d*\/\d\d*\/\d\d\d\d$">*</asp:RegularExpressionValidator>