<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationControl.ascx.cs" Inherits="NavigationControl" %>
<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink><br />
<asp:HyperLink ID="hlDetailsView" runat="server" NavigateUrl="~/DetailsViewExample.aspx">DetailsView</asp:HyperLink> |
<asp:HyperLink ID="hlFormView" runat="server" NavigateUrl="~/FormViewExample.aspx">FormView</asp:HyperLink> |
<asp:HyperLink ID="hlGridView" runat="server" NavigateUrl="~/GridViewExample.aspx">GridView</asp:HyperLink><br />
<div id="ViewStatePlaceHolder"></div>
<script type="text/javascript">
showViewStateLength();
</script>