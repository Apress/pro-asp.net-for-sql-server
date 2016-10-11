<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Website 2</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginName ID="LoginName1" runat="server" />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            <br />
        Last Login: <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
            User Data: <asp:Label ID="Label2" runat="server" Text=""></asp:Label><br />
            Remote Address Matched : <asp:Label ID="Label3" runat="server" Text=""></asp:Label><br />
            Font Size: <asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
            <br />
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate">
            </asp:Login>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete Inactive Profiles" /><br />
            <br />
            <asp:HyperLink ID="AdminHyperLink" runat="server" NavigateUrl="~/Admin/Default.aspx">HyperLink</asp:HyperLink></div>
    </form>
</body>
</html>
