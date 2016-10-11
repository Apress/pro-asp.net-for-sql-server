<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InputParameterExample.aspx.cs"
    Inherits="InputParameterExample" Title="Input Parameter Example" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <b>Select Last Name: </b>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1"
        DataTextField="LastName">
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        DataSourceID="ObjectDataSource2">
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetLastNames" 
        TypeName="Chapter04.PersonDomain"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetPeopleByLastName" 
        TypeName="Chapter04.PersonDomain">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="lastName" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
