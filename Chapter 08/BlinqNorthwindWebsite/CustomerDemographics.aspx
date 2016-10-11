<%@ Page  MasterPageFile="~/MasterPage.master" Title="CustomerDemographics"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>CustomerDemographics</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CustomerTypeID" EmptyDataText="No records were returned." DataSourceID="CustomerDemographicsDataSource" ID="CustomerDemographicsGridView"><Columns>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
<asp:BoundField DataField="CustomerTypeID" HeaderText="CustomerTypeID" ReadOnly="True" SortExpression="CustomerTypeID"></asp:BoundField>
<asp:BoundField DataField="CustomerDesc" HeaderText="CustomerDesc" SortExpression="CustomerDesc"></asp:BoundField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerTypeID," DataNavigateUrlFormatString="~/CustomerCustomerDemos.aspx?Table=CustomerDemographic_CustomerCustomerDemos&amp;CustomerCustomerDemos_CustomerTypeID={0}" Text="View CustomerCustomerDemos"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="CustomerTypeID" DataNavigateUrlFormatString="~/CustomerDemographicDetail.aspx?CustomerTypeID={0}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetAllCustomerDemographicsCount" SelectMethod="GetAllCustomerDemographics" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.CustomerDemographic" UpdateMethod="Update" ID="CustomerDemographicsDataSource"></asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewCustomerDemographic.aspx" CssClass="button" ID="NewRecordLink">Create New CustomerDemographic</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
