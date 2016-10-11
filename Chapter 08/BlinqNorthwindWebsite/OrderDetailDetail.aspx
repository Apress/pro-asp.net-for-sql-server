<%@ Page  MasterPageFile="~/MasterPage.master" Title="OrderDetail Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>OrderDetail Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="OrderID,ProductID" EmptyDataText="The requested record was not found." DataSourceID="OrderDetailsDataSource" ID="OrderDetailsDetailsView"><Fields>
<asp:TemplateField HeaderText="OrderID" SortExpression="OrderID"><ItemTemplate>
<asp:HyperLink ID="OrderIDLink" runat="server" Text='<%# Eval("OrderID") %>' NavigateUrl='<%# Eval("OrderID", "~/OrderDetail.aspx?OrderID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><ItemTemplate>
<asp:HyperLink ID="ProductIDLink" runat="server" Text='<%# Eval("ProductID") %>' NavigateUrl='<%# Eval("ProductID", "~/ProductDetail.aspx?ProductID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Quantity" HeaderText="Quantity" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Discount" HeaderText="Discount" InsertVisible="False"></asp:BoundField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOrderDetail" TypeName="Chapter08.BlinqNorthwindDAL.OrderDetail" UpdateMethod="Update" ID="OrderDetailsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="OrderID" Name="OrderID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
