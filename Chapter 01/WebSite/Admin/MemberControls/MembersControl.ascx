<%@ Control Language="C#" AutoEventWireup="true" 
  CodeFile="MembersControl.ascx.cs" 
  Inherits="MembersControl" %>
<%@ Register Src="UserManager.ascx" TagName="UserManager" TagPrefix="uc2" %>
<%@ Register Src="RolesManager.ascx" TagName="RolesManager" TagPrefix="uc1" %>

    <br />
    <br />
    <b>Select View:</b>
    <asp:DropDownList ID="NavDropDownList" runat="server" 
        AutoPostBack="True" 
        OnSelectedIndexChanged="NavDropDownList_SelectedIndexChanged">
        <asp:ListItem>Create User</asp:ListItem>
        <asp:ListItem>Manage Users</asp:ListItem>
        <asp:ListItem>Manage Roles</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    
    <asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="UserCreationView" runat="server" OnActivate="UserCreationView_Activate">  
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
                    AutoGeneratePassword="True"
                    LoginCreatedUser="False" 
                    OnCreatedUser="CreateUserWizard1_CreatedUser">
                    <WizardSteps>
                        <asp:CreateUserWizardStep 
                          ID="CreateUserWizardStep1" runat="server">
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep 
                          ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
    </asp:View>
    <asp:View ID="UserManagerView" runat="server" 
      OnActivate="UserManagerView_Activate">

                <uc2:UserManager 
                  ID="UserManager1" runat="server" 
                  Title="Users" 
                  TitleBold="true" />
    </asp:View>
    <asp:View ID="RolesManagerView" runat="server">
    
                <uc1:RolesManager 
                  ID="RolesManager1" runat="server" 
                  Title="Roles" />
    
    </asp:View>
    </asp:MultiView>