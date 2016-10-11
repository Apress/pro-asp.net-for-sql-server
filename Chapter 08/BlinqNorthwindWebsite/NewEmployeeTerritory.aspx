<%@ Page  MasterPageFile="~/MasterPage.master" Title="New EmployeeTerritory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>New EmployeeTerritory</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="EmployeeID,TerritoryID" DefaultMode="Insert" EmptyDataText="The requested record was not found." PageIndex="-1" DataSourceID="EmployeeTerritoriesDataSource" ID="EmployeeTerritoriesDetailsView"><Fields>
<asp:TemplateField HeaderText="EmployeeID" SortExpression="EmployeeID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllEmployees" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="Employee_EmployeeIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Employee_EmployeeIDList" DataTextField="EmployeeID" DataValueField="EmployeeID" SelectedValue='<%# Bind("EmployeeID") %>' DataSourceID="Employee_EmployeeIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TerritoryID" SortExpression="TerritoryID"><InsertItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Territory" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllTerritories" TypeName="Chapter08.BlinqNorthwindDAL.Territory" UpdateMethod="Update" ID="Territory_TerritoryIDDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="Territory_TerritoryIDList" DataTextField="TerritoryID" DataValueField="TerritoryID" SelectedValue='<%# Bind("TerritoryID") %>' DataSourceID="Territory_TerritoryIDDataSource" >
</asp:DropDownList>
</InsertItemTemplate>
</asp:TemplateField>
<asp:CommandField CancelText="Clear Values" ShowInsertButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployeeTerritory" TypeName="Chapter08.BlinqNorthwindDAL.EmployeeTerritory" UpdateMethod="Update" ID="EmployeeTerritoriesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="EmployeeID" Name="EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
<asp:QueryStringParameter QueryStringField="TerritoryID" Name="TerritoryID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
