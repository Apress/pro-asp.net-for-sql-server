<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true" CodeFile="DataSetPage.aspx.cs" Inherits="DataSetPage" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    &nbsp;<asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text="Repeater"></asp:Label>
    </ItemTemplate>
    </asp:Repeater>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Chapter07ConnectionString %>"
        SelectCommand="chpt07_GetLinkTagsByProfileID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="ProfileID" QueryStringField="ProfileID" Type="Int64" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

