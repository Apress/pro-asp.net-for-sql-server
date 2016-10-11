<%@ Page  MasterPageFile="~/MasterPage.master" Title="CustomerCustomerDemo Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>CustomerCustomerDemo Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CustomerID,CustomerTypeID" EmptyDataText="The requested record was not found." DataSourceID="CustomerCustomerDemosDataSource" ID="CustomerCustomerDemosDetailsView"><Fields>
<asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID"><ItemTemplate>
<asp:HyperLink ID="CustomerIDLink" runat="server" Text='<%# Eval("CustomerID") %>' NavigateUrl='<%# Eval("CustomerID", "~/CustomerDetail.aspx?CustomerID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CustomerTypeID" SortExpression="CustomerTypeID"><ItemTemplate>
<asp:HyperLink ID="CustomerTypeIDLink" runat="server" Text='<%# Eval("CustomerTypeID") %>' NavigateUrl='<%# Eval("CustomerTypeID", "~/CustomerDemographicDetail.aspx?CustomerTypeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerCustomerDemo" TypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" UpdateMethod="Update" ID="CustomerCustomerDemosDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CustomerID" Name="CustomerID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="CustomerTypeID" Name="CustomerTypeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
