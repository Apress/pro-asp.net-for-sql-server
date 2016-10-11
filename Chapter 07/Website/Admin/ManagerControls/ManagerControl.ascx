<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManagerControl.ascx.cs" Inherits="ManagerControl" %>
<%@ Register Src="UserManager.ascx" TagName="UserManager" TagPrefix="mc" %>
<%@ Register Src="RolesManager.ascx" TagName="RolesManager" TagPrefix="mc" %>

    <b>Select View:</b>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>Create User</asp:ListItem>
        <asp:ListItem>Manager Users</asp:ListItem>
        <asp:ListItem>Manage Roles</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    
    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="UserCreationView" runat="server">  
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" AutoGeneratePassword="True"
                    LoginCreatedUser="False" OnCreatedUser="CreateUserWizard1_CreatedUser">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
    </asp:View>
    <asp:View ID="UserManagerView" runat="server">

                <mc:UserManager ID="UserManager1" runat="server" Title="Users" TitleBold="true" />
    </asp:View>
    <asp:View ID="RolesManagerView" runat="server">
    
                <mc:RolesManager ID="RolesManager1" runat="server" Title="Roles" />
    
    </asp:View>
    </asp:MultiView>