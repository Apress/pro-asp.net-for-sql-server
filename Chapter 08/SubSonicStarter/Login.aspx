<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>Login</h1>
    
    <div id="centercontent">
    
        <table align="center" class="logtable">

            <tr>
                <td class="logincell">
              
                    <asp:Login ID="Login1" runat="server"
                    PasswordRecoveryText="Forgot Password?" 
                    PasswordRecoveryUrl="~/PasswordRecover.aspx" 
                        >
                    </asp:Login>
                </td>
                
            </tr>
        
        </table>
    
    </div>
</asp:Content>

