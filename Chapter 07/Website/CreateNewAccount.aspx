<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true" CodeFile="CreateNewAccount.aspx.cs" Inherits="CreateNewAccount" Title="Favorite Link: Create New Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" AutoGeneratePassword="True" OnCreatedUser="CreateUserWizard1_CreatedUser">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

