<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RolesManager.ascx.cs"
    Inherits="MemberControls_RolesManager" %>
<asp:Label ID="TitleLabel" runat="server" Text="Roles Manager" Font-Bold="true"></asp:Label>
<table>
    <tr>
        <td align="center">
            <asp:GridView ID="RolesGridView" runat="server" 
                AutoGenerateColumns="False"
                OnRowCommand="RolesGridView_RowCommand" 
                OnRowDataBound="RolesGridView_RowDataBound"
                GridLines="None" 
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" 
                                Text="Role"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Users">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" 
                                Text="Users"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField CommandName="RemoveRole" 
                        Text="Remove" />
                </Columns>
                <EmptyDataTemplate>
                    &nbsp;- No Roles -
                </EmptyDataTemplate>
                <RowStyle CssClass="EvenRow" />
                <AlternatingRowStyle CssClass="OddRow" />
                <HeaderStyle CssClass="HeaderRow" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="center">
            <asp:Label ID="Label3" runat="server" 
                Font-Bold="True" Text="Role: "></asp:Label>
            <asp:TextBox ID="AddRoleTextBox" runat="server" 
                Width="75px"></asp:TextBox>
            <asp:Button ID="AddRoleButton" runat="server" 
                Text="Add" OnClick="AddRoleButton_Click" /></td>
    </tr>
</table>
