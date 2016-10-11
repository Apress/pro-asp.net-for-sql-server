<%@ Page  MasterPageFile="~/MasterPage.master" Title="CustomerCustomerDemos"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>CustomerCustomerDemos</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CustomerID,CustomerTypeID" EmptyDataText="No records were returned." DataSourceID="CustomerCustomerDemosDataSource" ID="CustomerCustomerDemosGridView"><Columns>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID"><ItemTemplate>
<asp:HyperLink ID="CustomerIDLink" runat="server" Text='<%# Eval("CustomerID") %>' NavigateUrl='<%# Eval("CustomerID", "~/CustomerDetail.aspx?CustomerID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CustomerTypeID" SortExpression="CustomerTypeID"><ItemTemplate>
<asp:HyperLink ID="CustomerTypeIDLink" runat="server" Text='<%# Eval("CustomerTypeID") %>' NavigateUrl='<%# Eval("CustomerTypeID", "~/CustomerDemographicDetail.aspx?CustomerTypeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerID,CustomerTypeID" DataNavigateUrlFormatString="~/CustomerCustomerDemoDetail.aspx?CustomerID={0}&amp;CustomerTypeID={1}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetCustomerCustomerDemosCount" SelectMethod="GetCustomerCustomerDemos" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" UpdateMethod="Update" ID="CustomerCustomerDemosDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="CustomerCustomerDemos_CustomerTypeID" Name="CustomerCustomerDemos_CustomerTypeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="CustomerCustomerDemos_CustomerID" Name="CustomerCustomerDemos_CustomerID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewCustomerCustomerDemo.aspx" CssClass="button" ID="NewRecordLink">Create New CustomerCustomerDemo</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
