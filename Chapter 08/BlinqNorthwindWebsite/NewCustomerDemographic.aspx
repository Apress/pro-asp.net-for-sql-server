<%@ Page  MasterPageFile="~/MasterPage.master" Title="New CustomerDemographic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New CustomerDemographic</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="CustomerTypeID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="CustomerDemographicsDataSource" ID="CustomerDemographicsDetailsView"><Fields>
<asp:BoundField DataField="CustomerTypeID" HeaderText="CustomerTypeID" ReadOnly="True"></asp:BoundField>
<asp:BoundField DataField="CustomerDesc" HeaderText="CustomerDesc"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerTypeID," DataNavigateUrlFormatString="~/CustomerCustomerDemos.aspx?Table=CustomerDemographic_CustomerCustomerDemos&amp;CustomerCustomerDemos_CustomerTypeID={0}" Text="View CustomerCustomerDemos"></asp:HyperLinkField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerDemographic" TypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" UpdateMethod="Update" ID="CustomerDemographicsDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="CustomerTypeID" Name="CustomerTypeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
