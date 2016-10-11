<%@ Page  MasterPageFile="~/MasterPage.master" Title="Employee Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceholder" Runat="Server">
   <div class="pagecontent">
        <h1>Employee Detail</h1>      

<asp:DetailsView runat="server" AutoGenerateRows="False" DataKeyNames="EmployeeID" EmptyDataText="The requested record was not found." DataSourceID="EmployeesDataSource" ID="EmployeesDetailsView"><Fields>
<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="LastName" HeaderText="LastName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="FirstName" HeaderText="FirstName" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Title" HeaderText="Title" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="BirthDate" HeaderText="BirthDate" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="HireDate" HeaderText="HireDate" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Address" HeaderText="Address" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="City" HeaderText="City" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Region" HeaderText="Region" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="PostalCode" HeaderText="PostalCode" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Country" HeaderText="Country" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="HomePhone" HeaderText="HomePhone" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Extension" HeaderText="Extension" InsertVisible="False"></asp:BoundField>
<asp:BoundField DataField="Notes" HeaderText="Notes" InsertVisible="False"></asp:BoundField>
<asp:TemplateField HeaderText="ReportsTo" SortExpression="ReportsTo"><EditItemTemplate>
<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllEmployees" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="ReportsToEmployee_ReportsToDataSource"></asp:ObjectDataSource>

<asp:DropDownList runat="server" ID="ReportsToEmployee_ReportsToList" DataTextField="EmployeeID" DataValueField="EmployeeID" SelectedValue='<%# Bind("ReportsTo") %>' DataSourceID="ReportsToEmployee_ReportsToDataSource" AppendDataBoundItems="true" >
<asp:ListItem Text="<null>" Value="" />
</asp:DropDownList>
</EditItemTemplate>
<ItemTemplate>
<asp:HyperLink ID="ReportsToLink" runat="server" Text='<%# Eval("ReportsTo") %>' NavigateUrl='<%# Eval("ReportsTo", "~/EmployeeDetail.aspx?EmployeeID={0}")%>' />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="PhotoPath" HeaderText="PhotoPath" InsertVisible="False"></asp:BoundField>
<asp:CheckBoxField DataField="Deleted" HeaderText="Deleted" SortExpression="Deleted"></asp:CheckBoxField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/Employees.aspx?Table=Employee_Employees&amp;Employees_EmployeeID={0}" Text="View Employees"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/EmployeeTerritories.aspx?Table=Employee_EmployeeTerritories&amp;EmployeeTerritories_EmployeeID={0}" Text="View EmployeeTerritories"></asp:HyperLinkField>
<asp:HyperLinkField DataNavigateUrlFields="EmployeeID," DataNavigateUrlFormatString="~/Orders.aspx?Table=Employee_Orders&amp;Orders_EmployeeID={0}" Text="View Orders"></asp:HyperLinkField>
<asp:CommandField ShowDeleteButton="True" ShowEditButton="True"></asp:CommandField>
</Fields>
</asp:DetailsView>

<asp:ObjectDataSource runat="server" ConflictDetection="CompareAllValues" DataObjectTypeName="Chapter08.BlinqNorthwindDAL.Employee" DeleteMethod="Delete" EnableCaching="True" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetEmployee" TypeName="Chapter08.BlinqNorthwindDAL.Employee" UpdateMethod="Update" ID="EmployeesDataSource"><SelectParameters>
<asp:QueryStringParameter QueryStringField="EmployeeID" Name="EmployeeID" ConvertEmptyStringToNull="False"></asp:QueryStringParameter>
</SelectParameters>
</asp:ObjectDataSource>

    </div>
</asp:Content>
