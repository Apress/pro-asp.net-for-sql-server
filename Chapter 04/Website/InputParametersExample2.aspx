<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InputParametersExample2.aspx.cs" 
    Inherits="InputParametersExample2" Title="Input Parameter Example 2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <b>Select Last Name: </b>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
        DataTextField="LastName">
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        DataSourceID="ObjectDataSource2">
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetLastNames" TypeName="Chapter04.PersonDomain"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetPeopleByLastName" TypeName="Chapter04.PersonDomain" OnSelecting="ObjectDataSource2_Selecting">
        <SelectParameters>
            <asp:Parameter Name="lastName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

