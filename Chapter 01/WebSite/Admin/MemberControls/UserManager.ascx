<%@ Control Language="C#" AutoEventWireup="true" 
  CodeFile="UserManager.ascx.cs" Inherits="MemberControls_UserManager" %>
<asp:Label ID="TitleLabel" 
  runat="server" Text="User Manager"></asp:Label><br />
<asp:MultiView ID="UsersMultiView" runat="server" 
  ActiveViewIndex="0">
    <asp:View ID="SelectUserView" runat="server" 
      OnActivate="SelectUserView_Activate">
    
        <table>
        <tr>
        <td>
            <asp:GridView ID="UsersGridView" runat="server" 
                AllowPaging="True" 
                AutoGenerateColumns="False"
                OnInit="UsersGridView_Init" 
                OnPageIndexChanging="UsersGridView_PageIndexChanging"
                OnRowCommand="UsersGridView_RowCommand" 
                GridLines="None">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                CausesValidation="false" 
                                CommandName="ViewUser"
                                CommandArgument='<%# Bind("UserName") %>'
                                Text="View"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="EvenRow" />
                <HeaderStyle CssClass="HeaderRow" />
                <AlternatingRowStyle CssClass="OddRow" />
            </asp:GridView>
        </td>
        </tr>
        <tr>
        <td align="center">
            <asp:TextBox ID="FilterUsersTextBox" runat="server" 
                Width="75px"></asp:TextBox>
            <asp:Button ID="FilterUsersButton" runat="server" 
                OnClick="FilterUsersButton_Click" Text="Filter" />
        </td>
        </tr>
        </table>
            
    </asp:View>
    <asp:View ID="UserView" runat="server" OnActivate="UserView_Activate">
    
    <table>
        <tr>
            <td class="Label">
                <asp:Label ID="UserNameLabel" runat="server" Text="User Name: " 
                    Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="UserNameValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="ApprovedLabel" runat="server" Text="Approved: " 
                    Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="ApprovedValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="LockedOutLabel" runat="server" Text="Locked Out: " 
                    Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="LockedOutValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="OnlineLabel" runat="server" Text="Online: " 
                    Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="OnlineValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="CreationLabel" runat="server" Text="Creation: " 
                    Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="CreationValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="LastActivityLabel" runat="server" 
                    Text="Last Activity:" Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="LastActivityValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="LastLoginLabel" runat="server" 
                    Text="Last Login:" Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="LastLoginValueLabel" runat="server" 
                    Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" class="Data">
                <asp:Label ID="UserCommentLabel" runat="server" 
                    Text="Comment:" Font-Bold="True"></asp:Label><br />
                <asp:Label ID="UserCommentValueLabel" runat="server" 
                    Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="EditUserButton" runat="server" 
                    Text="Edit User" OnClick="EditUserButton_Click" />
                <asp:Button ID="ResetPasswordButton" runat="server" 
                    Text="Reset Password" OnClick="ResetPasswordButton_Click" 
                    Visible="False" />
                <asp:Button ID="UnlockUserButton" runat="server" 
                    OnClick="UnlockUserButton_Click" Text="Unlock" />
                <asp:Button ID="ReturnViewUserButton" runat="server" 
                    Text="Return" OnClick="ReturnViewUserButton_Click" />
            </td>
        </tr>
    </table>
    
    </asp:View>
    <asp:View ID="EditorView" runat="server" OnActivate="EditorView_Activate">
    
    <table>
        <tr>
            <td class="Label">
                <asp:Label ID="UserName2Label" runat="server" Text="User Name: " Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:Label ID="UserNameValue2Label" runat="server" Text=""></asp:Label></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="EmailLabel" runat="server" Text="Email: " Font-Bold="True"></asp:Label>
            </td>
            <td class="Data">
                <asp:TextBox ID="EmailTextBox" runat="server" AutoCompleteType="Email"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator 
                  ID="EmailRequiredFieldValidator" runat="server" 
                  ErrorMessage="*" 
                  ControlToValidate="EmailTextBox" 
                  EnableClientScript="False"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator 
                  ID="RegularExpressionValidator1" runat="server" 
                  ControlToValidate="EmailTextBox"
                    EnableClientScript="False" 
                    ErrorMessage="*" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td class="Label">
                <asp:Label ID="CommentLabel" runat="server" Text="Comment: " Font-Bold="True"></asp:Label>
            </td>
            <td class="Data">
                <asp:TextBox ID="CommentTextBox" runat="server" AutoCompleteType="Email" TextMode="MultiLine"></asp:TextBox></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <td class="Label"><asp:Label ID="Approved2Label" runat="server" Text="Approved: " Font-Bold="True"></asp:Label></td>
        <td class="Data"><asp:CheckBox ID="ApprovedCheckBox" runat="server" /></td>
        <td></td>
        </tr>
        <tr>
        <td class="Label"><asp:Label ID="RolesLabel" runat="server" Text="Roles " Font-Bold="True"></asp:Label></td>
            <td class="Data">
                <asp:CheckBoxList ID="RolesCheckBoxList" runat="server">
                </asp:CheckBoxList>
            </td>
        <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="UpdateUserButton" runat="server" Text="Update User" OnClick="UpdateUserButton_Click" />
                <asp:Button ID="CancelEditUserButton" runat="server" OnClick="CancelEditUserButton_Click"
                    Text="Cancel" /></td>
        </tr>
    </table>
    
    </asp:View>
</asp:MultiView>

