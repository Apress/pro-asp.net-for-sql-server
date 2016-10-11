<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CreateCustomUserControl.ascx.cs" Inherits="Controls_CreateCustomUserControl" %>
<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
    OnCreatedUser="CreateUserWizard1_CreatedUser"
    ContinueDestinationPageUrl="~/Default.aspx">
    <WizardSteps>
        <asp:WizardStep runat="server" Title="Primary Interest">

        <b>Select your primary interest:</b><br />
        <asp:RadioButtonList ID="rblPrimaryInterest" runat="server">
            <asp:ListItem Selected="True" Value="1">Sports</asp:ListItem>
            <asp:ListItem Value="2">Politics</asp:ListItem>
            <asp:ListItem Value="3">Weather</asp:ListItem>
            <asp:ListItem Value="4">Business</asp:ListItem>
            <asp:ListItem Value="5">Entertainment</asp:ListItem>
        </asp:RadioButtonList>
        
        <p>
        Please choose the font size below which you feel
        is most readable.
        </p>
        
        <table><tr><td>
        <b>Sample Sizes:</b> 
        <div style="font-size: 10px;">Small Font Size</div>
        <div style="font-size: 12px;">Regular Font Size</div>
        <div style="font-size: 14px;">Large Font Size</div>
        
        </td><td>
        <asp:RadioButtonList ID="rblFontSize" runat="server">
            <asp:ListItem Value="10">Small</asp:ListItem>
            <asp:ListItem Selected="True" Value="12">Regular</asp:ListItem>
            <asp:ListItem Value="14">Large</asp:ListItem>
        </asp:RadioButtonList>
        
        </td></tr></table>
        
        </asp:WizardStep>
        <asp:CreateUserWizardStep runat="server">
        </asp:CreateUserWizardStep>
        <asp:CompleteWizardStep runat="server">
        </asp:CompleteWizardStep>
    </WizardSteps>
</asp:CreateUserWizard>
