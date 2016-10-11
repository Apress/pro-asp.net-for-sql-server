<%@ Page  MasterPageFile="~/MasterPage.master" Title="New CustomerCustomerDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New CustomerCustomerDemo</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CustomerID,CustomerTypeID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="CustomerCustomerDemosDataSource" ID="CustomerCustomerDemosDetailsView"><Fields>
<asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Customer" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCustomers" TypeName="Chapter08.BlinqNorthwindDAL.Customer" UpdateMethod="Update" ID="Customer_CustomerIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Customer_CustomerIDList" DataTextField="CustomerID" DataValueField="CustomerID" SelectedValue='<%# Bind("CustomerID") %>' DataSourceID="Customer_CustomerIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="CustomerTypeID" SortExpression="CustomerTypeID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllCustomerDemographics" TypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" UpdateMethod="Update" ID="CustomerDemographic_CustomerTypeIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="CustomerDemographic_CustomerTypeIDList" DataTextField="CustomerTypeID" DataValueField="CustomerTypeID" SelectedValue='<%# Bind("CustomerTypeID") %>' DataSourceID="CustomerDemographic_CustomerTypeIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerCustomerDemo" TypeName="Chapter08.BlinqNorthwindDAL.CustomerCustomerDemo" UpdateMethod="Update" ID="CustomerCustomerDemosDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CustomerID" Name="CustomerID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="CustomerTypeID" Name="CustomerTypeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
