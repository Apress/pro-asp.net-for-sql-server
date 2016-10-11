<%@ Page  MasterPageFile="~/MasterPage.master" Title="EmployeeTerritories"%>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>EmployeeTerritories</h1>
<asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="EmployeeID,TerritoryID" EmptyDataText="No records were returned." DataSourceID="EmployeeTerritoriesDataSource" ID="EmployeeTerritoriesGridView"><Columns>
<asp:CommandField ShowDeleteButton="True"></asp:CommandField>
<asp:TemplateField HeaderText="EmployeeID" SortExpression="EmployeeID"><ItemTemplate>
<asp:HyperLink ID="EmployeeIDLink" runat="server" Text='<%# Eval("EmployeeID") %>' NavigateUrl='<%# Eval("EmployeeID", "~/EmployeeDetail.aspx?EmployeeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TerritoryID" SortExpression="TerritoryID"><ItemTemplate>
<asp:HyperLink ID="TerritoryIDLink" runat="server" Text='<%# Eval("TerritoryID") %>' NavigateUrl='<%# Eval("TerritoryID", "~/TerritoryDetail.aspx?TerritoryID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID,TerritoryID" DataNavigateUrlFormatString="~/EmployeeTerritoryDetail.aspx?EmployeeID={0}&amp;TerritoryID={1}" Text="View Details"></asp:HyperLinkField>
</Columns>
</asp:GridView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" DeleteMethod="Delete" EnablePaging="True" OldValuesParameterFormatString="original_{0}" SelectCountMethod="GetEmployeeTerritoriesCount" SelectMethod="GetEmployeeTerritories" SortParameterName="sortExpression" TypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" UpdateMethod="Update" ID="EmployeeTerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="Table" Name="tableName"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="EmployeeTerritories_EmployeeID" Name="EmployeeTerritories_EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="EmployeeTerritories_TerritoryID" Name="EmployeeTerritories_TerritoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

        <div class="link">
        <asp:HyperLink runat="server" NavigateUrl="~/NewEmployeeTerritory.aspx" CssClass="button" ID="NewRecordLink">Create New EmployeeTerritory</asp:HyperLink>

        </div>    
    </div>
</asp:Content>
