<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="Albums_Default" Title="Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <h3>Albums</h3>
    <asp:Repeater ID="Repeater1" runat="server" EnableViewState="false" DataSourceID="ObjectDataSource1"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <ul class="Albums">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Name") %>'></asp:HyperLink></li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}"
        OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetAlbums" TypeName="Domain">
        <SelectParameters>
            <asp:Parameter Name="userName" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <h3>Add an Album</h3>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AddAlbumGroup" />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblAlbumName" runat="server" Text="Album Name:" Font-Bold="True"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbAlbumName" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvAlbumName" runat="server" ErrorMessage="Album name is required" Display="Dynamic" ControlToValidate="tbAlbumName" ValidationGroup="AddAlbumGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFlickrTag" runat="server" Text="Flickr Tag:" Font-Bold="True"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbFlickrTag" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="rfvFlickrTag" runat="server" ErrorMessage="Flickr tag is required" Display="Dynamic" ControlToValidate="tbFlickrTag" ValidationGroup="AddAlbumGroup">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center;">
            <asp:Button ID="btnAddAlbum" runat="server" Text="Add Album" OnClick="btnAddAlbum_Click" ValidationGroup="AddAlbumGroup" />
            </td>
        </tr>
    </table>
    
    <h3>Remove an Album</h3>
    <asp:DropDownList ID="ddlAlbums" runat="server" DataSourceID="ObjectDataSource1"
        DataTextField="Name" DataValueField="Name" ValidationGroup="RemoveAlbumGroup">
    </asp:DropDownList>
    <asp:Button ID="btnRemoveAlbum" runat="server" OnClick="btnRemoveAlbum_Click" Text="Remove Album"
        ValidationGroup="RemoveAlbumGroup" /><br />
    <br />
    <h3>Import Default Albums</h3>
    <asp:Button ID="btnImportPhotos" runat="server" OnClick="btnImportPhotos_Click" Text="Import Default Flickr Albums" /><br />
</asp:Content>
