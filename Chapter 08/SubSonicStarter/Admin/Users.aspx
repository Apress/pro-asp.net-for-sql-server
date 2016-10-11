<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/site.master" CodeFile="Users.aspx.cs" Inherits="Admin_admin_users" Title="User Administration" Trace="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="centercontent">
<br />
    <div style="padding-bottom:5px" >
        <b>Users</b> | 
        <b><a href="users_edit.aspx">Add User</a></b> | 
        <b><a href="roles.aspx">Roles</a></b>
    </div>
    
    <br />
    
    <table cellspacing="0" cellpadding="0" class="lrbBorders" width="750">
        <tr >
            <td class="bodyTextLowTopPadding">
                <asp:Label ID="Label1" runat="server" AssociatedControlID="SearchByDropDown" Text="Search By: " Font-Bold="true" CssClass="adminlabel"/>
                <asp:dropDownList runat="server" id="SearchByDropDown" CssClass="adminitem">
                    <asp:listItem text="Username" />
                    <asp:listitem text="Email" />
                </asp:dropDownList>&nbsp;&nbsp;
                <asp:textbox runat="server" id="TextBox1" BorderStyle="Solid"/>
                <asp:button ID="Button1" runat="server" text="Search for Users" onclick="SearchForUsers" CssClass="frmbutton"/>
                <br/>
            </td>
        </tr>
    </table>

    <br />

    <asp:GridView ID="GridView1" runat="server" SkinID=subsonicSkin 
        AutoGenerateColumns="False" 
        DataSourceID="allUsersDataSource" 
        EmptyDataText="There are no matching users in the system." 
        Font-Italic="False" >
        <Columns>
            <asp:templatefield headertext="Active" ItemStyle-Width="40" ItemStyle-HorizontalAlign="Center">
                <headerstyle horizontalalign="center"/>
                <itemstyle horizontalalign="center"/>
                <itemtemplate>
                    <asp:checkBox runat="server" id="CheckBox1" oncheckedchanged="EnabledChanged" autopostback="true" checked='<%#DataBinder.Eval(Container.DataItem, "IsApproved")%>' Value='<%#DataBinder.Eval(Container.DataItem, "UserName")%>'/>
                </itemtemplate>
            </asp:templatefield>
            <asp:templatefield runat="server" headertext="User Name" ItemStyle-Width="160" >
                <itemtemplate>
                    <a href='users_edit.aspx?username=<%#Eval("UserName")%>'><%#DataBinder.Eval(Container.DataItem, "UserName")%></a>
                </itemtemplate>
            </asp:templatefield>                            
            <asp:TemplateField HeaderText="Email" ItemStyle-Width="180" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:HyperLink ID="EmailLink" runat="server" NavigateUrl='<%# Eval("Email", "mailto:{0}") %>' Text='<%# Eval("Email") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreationDate" HeaderText="Created On" ReadOnly="True" SortExpression="CreationDate" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="LastLoginDate" HeaderText="Last Login" SortExpression="LastLoginDate" ItemStyle-HorizontalAlign="Center"/>
            <asp:templatefield runat="server" ItemStyle-HorizontalAlign="Center">
                <itemtemplate>
                    <asp:linkButton runat="server" id="linkButton2" text="Delete" commandname="delete" commandargument='<%#DataBinder.Eval(Container.DataItem, "UserName")%>' forecolor="black" oncommand="LinkButtonClick"/>
                </itemtemplate>
            </asp:templatefield>
        </Columns>
        <EmptyDataRowStyle Font-Italic="True" />
    </asp:GridView>

    <div style="margin-top:5px ">
    </div>
    
    <br />
           
    <asp:ObjectDataSource ID="allUsersDataSource" runat="server" 
        SelectMethod="GetAllUsers" 
        TypeName="System.Web.Security.Membership" 
        OnSelected="allUsersDataSource_Selected">
    </asp:ObjectDataSource>
</div>
</asp:Content>
