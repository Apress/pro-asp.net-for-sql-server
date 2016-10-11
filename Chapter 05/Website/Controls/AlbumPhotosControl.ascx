<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AlbumPhotosControl.ascx.cs" Inherits="Controls_AlbumPhotosControl" %>

<asp:Repeater ID="rptAlbums" runat="server" 
    DataSourceID="ObjectDataSource1" 
    OnItemDataBound="rptAlbums_ItemDataBound">
<ItemTemplate>
<div class="imgbox"><div class="imgblock">
<asp:HyperLink ID="HyperLink1" runat="server" 
    NavigateUrl='<%# Bind("RegularUrl") %>' CssClass="thickbox">
    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ThumbnailUrl") %>' 
        CssClass="photo" /><br />
        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
    </asp:HyperLink>
</div></div>
</ItemTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    SelectMethod="GetPhotosByAlbum" 
    TypeName="Domain" 
    OldValuesParameterFormatString="original_{0}" 
    OnSelecting="ObjectDataSource1_Selecting">
    <SelectParameters>
        <asp:Parameter Name="album" Type="Object" />
    </SelectParameters>
</asp:ObjectDataSource>
