<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Profile.ascx.cs" Inherits="Controls_Profile" %>
<asp:ValidationSummary ID="vsProfile" runat="server" ValidationGroup="Profile" />
<asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
<br />
<table border="0">
    <tr>
        <td class="label">
            First Name
        </td>
        <td>
            <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvFirstName" runat="server" ErrorMessage="First Name is required" ControlToValidate="tbFirstName"
                Display="Dynamic" ValidationGroup="Profile">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="label">
            Last Name
        </td>
        <td>
            <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvLastName" runat="server" ErrorMessage="Last Name is required" ControlToValidate="tbLastName"
                Display="Dynamic" ValidationGroup="Profile">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="label">
            Birth Date
        </td>
        <td>
            <asp:ListBox ID="lbBirthMonth" runat="server" Rows="1"></asp:ListBox>
            <asp:ListBox ID="lbBirthDay" runat="server" Rows="1"></asp:ListBox>
            <asp:ListBox ID="lbBirthYear" runat="server" Rows="1"></asp:ListBox>
            <asp:CustomValidator ID="cvBirthDate" runat="server" ErrorMessage="Birth Date is not valid"
                Display="Dynamic" OnServerValidate="cvBirthDate_ServerValidate" ValidationGroup="Profile">*</asp:CustomValidator></td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSaveProfile" runat="server" Text="Save Profile" OnClick="btnSaveProfile_Click"
                ValidationGroup="Profile" /></td>
    </tr>
</table>
