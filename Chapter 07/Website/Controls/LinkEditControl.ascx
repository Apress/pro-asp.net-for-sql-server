<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LinkEditControl.ascx.cs"
    Inherits="Controls_LinkEditControl" %>
<table>
    <tr>
        <td>
        </td>
        <td colspan="2">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </td>
    </tr>
    <tr id="updateRow" runat="server" visible="false">
        <td>
        </td>
        <td colspan="2">
            <asp:Label ID="lblUpdate" runat="server" Font-Bold="true">Updating Favorite Link...</asp:Label>
        </td>
    </tr>
    <tr>
        <td class="header">
            Title:
        </td>
        <td>
            <asp:TextBox ID="tbTitle" runat="server" MaxLength="150" Width="350px"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="tbTitle"
                Display="Dynamic" ErrorMessage="Title is required">*</asp:RequiredFieldValidator></td>
    </tr>
    <tr>
        <td class="header">
            Url:</td>
        <td>
            <asp:TextBox ID="tbUrl" runat="server" MaxLength="250" Width="350px"></asp:TextBox></td>
        <td>
            <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="tbUrl"
                Display="Dynamic" ErrorMessage="Url is required">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                    ID="revUrl" runat="server" ControlToValidate="tbUrl" ErrorMessage="Url is not valid"
                    Display="Dynamic" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w-: ,./?%&#@~!$\(\)=]*)?">*</asp:RegularExpressionValidator></td>
    </tr>
    <tr>
        <td class="header">
            Tags:</td>
        <td>
            <asp:TextBox ID="tbTags" runat="server" MaxLength="100" Width="350px"></asp:TextBox></td>
        <td>
            space-delimited
        </td>
    </tr>
    <tr>
        <td class="header">
            Note:
        </td>
        <td>
            <asp:TextBox ID="tbNote" runat="server" Height="50px" TextMode="MultiLine" Width="350px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="header">
            Rating:
        </td>
        <td>
            <asp:RadioButtonList ID="rblRating" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <asp:ListItem Selected="True">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList></td>
        <td>
        </td>
    </tr>
    <tr>
        <td class="header">
            Keeper:
        </td>
        <td>
            <asp:CheckBox ID="cbKeeper" runat="server" Checked="true" />
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td colspan="2">
            <asp:Button ID="btnSave" runat="server" Text="Save Link" OnClick="btnSave_Click" />
            <asp:HiddenField ID="hdnOldFavoriteLinkId" runat="server" Value="0" />
        </td>
    </tr>
</table>
