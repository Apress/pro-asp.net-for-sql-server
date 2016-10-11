<%@ Page Language="C#" MasterPageFile="~/Chapter01.master" AutoEventWireup="true" CodeFile="CreateNewAccount.aspx.cs" Inherits="CreateNewAccount" Title="Chapter 1: Create New Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" AutoGeneratePassword="True"
        FinishDestinationPageUrl="~/Home.aspx" ContinueDestinationPageUrl="~/Home.aspx">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep runat="server">
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>

