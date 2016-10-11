<%@ Page  MasterPageFile="~/MasterPage.master" Title="EmployeeTerritory Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>EmployeeTerritory Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="EmployeeID,TerritoryID" EmptyDataText="The requested record was not found." DataSourceID="EmployeeTerritoriesDataSource" ID="EmployeeTerritoriesDetailsView"><Fields>
<asp:TemplateField HeaderText="EmployeeID" SortExpression="EmployeeID"><ItemTemplate>
<asp:HyperLink ID="EmployeeIDLink" runat="server" Text='<%# Eval("EmployeeID") %>' NavigateUrl='<%# Eval("EmployeeID", "~/EmployeeDetail.aspx?EmployeeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TerritoryID" SortExpression="TerritoryID"><ItemTemplate>
<asp:HyperLink ID="TerritoryIDLink" runat="server" Text='<%# Eval("TerritoryID") %>' NavigateUrl='<%# Eval("TerritoryID", "~/TerritoryDetail.aspx?TerritoryID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployeeTerritory" TypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" UpdateMethod="Update" ID="EmployeeTerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="EmployeeID" Name="EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="TerritoryID" Name="TerritoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
