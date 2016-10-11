<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<asp:ScriptManager ID=elScripto runat=server></asp:ScriptManager>
    <asp:UpdateProgress runat=server ID=elProgress AssociatedUpdatePanelID="elSwingy">
        <ProgressTemplate>
            <div class="loadingbox">
                <img src="images/spinner.gif" align="absmiddle" />&nbsp;&nbsp;<asp:Label ID="lblProgress"
                    runat="server">Processing...</asp:Label>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:UpdatePanel ID=elSwingy runat=server>
<ContentTemplate>
<h1>Register With Us</h1>
<table width=800 align=center>
    <tr>
        <td >
            <div style="height:250px;overflow-y:scroll">
            
            <cms:Paragraph ID="Paragraph1" runat="server" ContentName="termsofuse"/>
            </div>
        </td>
    </tr>
    <tr>
        <td><asp:CheckBox Text="I agree to the terms of use" ID=chkAgree runat=server AutoPostBack="True" /></td>
    </tr>
 </table>

<table width=800 align=center>
    <tr><td> <h3>About You</h3></td></tr>
    <tr>
        <td>
        First Name<br />
        <asp:TextBox ID=txtFirst runat=server></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirst"
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr>
     <tr>
        <td>
        Last Name<br />
        <asp:TextBox ID=txtLast runat=server></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirst"
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr>
        <tr>
        <td>
        Email<br />
        <asp:TextBox ID=txtEmail runat=server></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirst"
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr>
</table>
<table width=800 align=center>
    <tr><td> <h3>Membership Bits</h3></td></tr>
        <tr>
        <td>
        Login<br />
        <asp:TextBox ID=txtLogin runat=server></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirst"
                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <cms:ResultMessage ID="ResultMessage2" runat="server" />
        </td>
    </tr> 
    <tr>  
         <td>
       Password<br />
        <asp:TextBox ID=txtPassword runat=server TextMode=Password></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                 Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr> 
    <tr>  
         <td>
        Confirm<br />
        </strong>
        <asp:TextBox ID=TextBox1 runat=server TextMode=Password></asp:TextBox>
             <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                 ControlToValidate="TextBox1" ErrorMessage="Passwords don't match"></asp:CompareValidator></td>
    </tr>
     <tr>  
         <td>
        Password Reminder Question<br />
        <asp:TextBox ID=txtQ runat=server ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtQ"
                 Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr> 
        <tr>  
         <td>
        Password Reminder Answer<br />
        <asp:TextBox ID=txtA runat=server ></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtA"
                 Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr>    
    
      
    <tr>
        <td><asp:Button ID=btnRegister runat=server Text=Register OnClick="btnRegister_Click" />
            <cms:ResultMessage ID="ResultMessage1" runat="server" />
        </td>
    </tr>
</table>

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

