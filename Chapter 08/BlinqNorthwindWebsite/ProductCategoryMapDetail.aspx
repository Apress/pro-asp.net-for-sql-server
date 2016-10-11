<%@ Page  MasterPageFile="~/MasterPage.master" Title="ProductCategoryMap Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>ProductCategoryMap Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CategoryID,ProductID" EmptyDataText="The requested record was not found." DataSourceID="ProductCategoryMapsDataSource" ID="ProductCategoryMapsDetailsView"><Fields>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID"><ItemTemplate>
<asp:HyperLink ID="CategoryIDLink" runat="server" Text='<%# Eval("CategoryID") %>' NavigateUrl='<%# Eval("CategoryID", "~/CategoryDetail.aspx?CategoryID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><ItemTemplate>
<asp:HyperLink ID="ProductIDLink" runat="server" Text='<%# Eval("ProductID") %>' NavigateUrl='<%# Eval("ProductID", "~/ProductDetail.aspx?ProductID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetProductCategoryMap" TypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" UpdateMethod="Update" ID="ProductCategoryMapsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CategoryID" Name="CategoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductID" Name="ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
