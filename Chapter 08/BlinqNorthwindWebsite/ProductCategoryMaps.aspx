<%@ Page  MasterPageFile="~/MasterPage.master" Title="ProductCategoryMaps"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>ProductCategoryMaps</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CategoryID,ProductID" EmptyDataText="No records were returned." DataSourceID="ProductCategoryMapsDataSource" ID="ProductCategoryMapsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:TemplateField HeaderText="CategoryID" SortExpression="CategoryID"><ItemTemplate>
<asp:HyperLink ID="CategoryIDLink" runat="server" Text='<%# Eval("CategoryID") %>' NavigateUrl='<%# Eval("CategoryID", "~/CategoryDetail.aspx?CategoryID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ProductID" SortExpression="ProductID"><ItemTemplate>
<asp:HyperLink ID="ProductIDLink" runat="server" Text='<%# Eval("ProductID") %>' NavigateUrl='<%# Eval("ProductID", "~/ProductDetail.aspx?ProductID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="CategoryID,ProductID" DataNavigateUrlFormatString="~/ProductCategoryMapDetail.aspx?CategoryID={0}&amp;ProductID={1}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetProductCategoryMapsCount" SelectMethod="GetProductCategoryMaps" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.ProductCategoryMap" UpdateMethod="Update" ID="ProductCategoryMapsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductCategoryMaps_CategoryID" Name="ProductCategoryMaps_CategoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="ProductCategoryMaps_ProductID" Name="ProductCategoryMaps_ProductID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewProductCategoryMap.aspx" CssClass="button" ID="NewRecordLink">Create New ProductCategoryMap</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
