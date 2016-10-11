<%@ Page  MasterPageFile="~/MasterPage.master" Title="OrderDetails"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>OrderDetails</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="OrderID,ProductID" EmptyDataText="No records were returned." DataSourceID="OrderDetailsDataSource" ID="OrderDetailsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:TemplateField HeaderText="OrderID" SortExpression="OrderID"><ItemTemplate>
<asp:HyperLink ID="OrderIDLink" runat="server" Text='<%# Eval("OrderID") %>' NavigateUrl='<%# Eval("OrderID", "~/OrderDetail.aspx?OrderID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><ItemTemplate>
<asp:HyperLink ID="ProductIDLink" runat="server" Text='<%# Eval("ProductID") %>' NavigateUrl='<%# Eval("ProductID", "~/ProductDetail.aspx?ProductID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice"></asp:BoundField>
<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
<asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="OrderID,ProductID" DataNavigateUrlFormatString="~/OrderDetailDetail.aspx?OrderID={0}&amp;ProductID={1}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetOrderDetailsCount" SelectMethod="GetOrderDetails" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" UpdateMethod="Update" ID="OrderDetailsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="OrderDetails_OrderID" Name="OrderDetails_OrderID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="OrderDetails_ProductID" Name="OrderDetails_ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewOrderDetail.aspx" CssClass="button" ID="NewRecordLink">Create New OrderDetail</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
