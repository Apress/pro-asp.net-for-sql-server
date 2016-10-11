<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Users_edit.aspx.cs" Inherits="admin_user_edit" Title="Edit User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellspacing="0" cellpadding="0" border="0"  width="750">
    <tbody>
    <tr align="left" valign="top">
        <td width="62%" height="100%" class="lbBorders">

            <table class="bodyText" cellspacing="0" width="100%" cellpadding="0" border="0">
                <tr class="callOutStyleLowLeftPadding">
                    <td colspan="4">
                        <h1><asp:literal ID="ActionTitle" runat="server" text="Edit User" /></h1>
                    </td>                    
                </tr>
                <tr id="trResultRow" runat="server" visible="false">
                    <td colspan="4">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="bodyText" bordercolor="#ccddef">
                            <tr>
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="UserID" Text="Username: " CssClass="adminlabel"/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="UserID" maxlength="255" tabindex="101" Columns="30"  CssClass="adminlabel"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserID" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="Email" Text="Email Address: " CssClass="adminlabel"/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="Email" maxlength="128" tabindex="102" Columns="30" CssClass="adminlabel" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="PasswordRow" runat="server" visible="false">
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="lblPassword" runat="server" AssociatedControlID="Password" Text="Password: "/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="Password" maxlength="50" tabindex="103" Columns="20" TextMode="Password" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="NewPasswordRow" runat="server" visible="false">
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="NewPassword" Text="New Password: "/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="NewPassword" maxlength="50" tabindex="103" Columns="20" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NewPassword" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="SecretQuestionRow" runat="server" visible="false">
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" AssociatedControlID="SecretQuestion" Text="Secret Question: "/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="SecretQuestion" maxlength="128" tabindex="104" Columns="30" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SecretQuestion" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="SecretAnswerRow" runat="server" visible="false">
                                <td width="2"></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" AssociatedControlID="SecretAnswer" Text="Secret Answer: "/>
                                </td>
                                <td>
                                    <asp:textbox runat="server" id="SecretAnswer" maxlength="128" tabindex="105" Columns="30" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SecretAnswer" Display="Dynamic" EnableClientScript="true">required</asp:RequiredFieldValidator>
                                </td>
                            </tr>  
                            <tr>
                                <td width="2"></td>
                                <td colspan="2">
                                    <asp:checkbox runat="server" id="ActiveUser" text="Active User" TabIndex="106" Checked="True"/>
                                </td>
                            </tr>   
                                                        <tr>
                                <td width="2"></td>
                                <td colspan="2">
                                    <asp:button runat="server" id="unlockUser" text="Unlock Account" TabIndex="107" OnClick="unlockAccount_Click" CssClass="frmbutton"/></td>
                            </tr>                                                      
                                                  
                            <tr valign="top">
                                <td width="2"></td>
                                <td  class="userDetailsWithFontSize" height="100%" colspan="2">
                                    <br />
                                    <h1><asp:label runat="server" id="SelectRolesLabel" text="Select User Roles"/></h1>
                                </td>
                            </tr>
                            <tr>
                                <td width="2"></td>
                                <td colspan="2">
                                    <asp:repeater runat="server" id="CheckBoxRepeater">
                                        <itemtemplate>
                                            <asp:checkbox runat="server" id="checkBox1" text='<%# Container.DataItem.ToString()%>' checked='<%# IsUserInRole(Container.DataItem.ToString())%>' CssClass="adminlabel"/>
                                            <br/>
                                        </itemtemplate>
                                    </asp:repeater>
                                </td>
                            </tr>
                            <tr>                                
                               <td colSpan="3">
                                    <br />
                                    <asp:button runat="server" id="SaveButton" onClick="SaveClick" text="Save" width="100" CssClass="frmbutton"/>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <br /><br />
                                    <a href="users.aspx" class="frmbutton">Back to user list.</a>
                                </td>
                            </tr>
                        </table>                        
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    </tbody>
</table>
</asp:Content>
