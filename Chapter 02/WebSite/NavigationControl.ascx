<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationControl.ascx.cs" Inherits="NavigationControl" %>
<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink><br />
DataReader:
<asp:HyperLink ID="hlDataReader" runat="server" NavigateUrl="~/DataReaderBasic.aspx">Basic</asp:HyperLink><br />
DataSet:
<asp:HyperLink ID="hlDataSet" runat="server" NavigateUrl="~/DataSetBasic.aspx">Basic</asp:HyperLink>, 
<asp:HyperLink ID="hlDataSet3" runat="server" NavigateUrl="~/TypedDataSet.aspx">Typed DataSet</asp:HyperLink><br />
<div id="ViewStatePlaceHolder"></div>
<script type="text/javascript">
showViewStateLength();
</script>