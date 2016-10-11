<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryControl.ascx.cs" Inherits="Controls_GalleryControl" %>
<%@ Register Src="AlbumPhotosControl.ascx" TagName="AlbumPhotosControl" TagPrefix="uc1" %>

<h1>Gallery</h1>

<asp:Repeater ID="rptAlbums" runat="server" DataSourceID="ObjectDataSource1" OnItemDataBound="rptAlbums_ItemDataBound" OnItemCreated="rptAlbums_ItemCreated">
<HeaderTemplate>
<div class="gallery">
</HeaderTemplate>
<ItemTemplate>
<h2><asp:Label ID="lblAlbumName" runat="server" Text='<%# Bind("Name") %>'></asp:Label></h2>
<uc1:AlbumPhotosControl ID="AlbumPhotosControl1" runat="server" />
</ItemTemplate>
<SeparatorTemplate>
<br style="clear: both;" />
</SeparatorTemplate>
<FooterTemplate>
</div>
</FooterTemplate>
</asp:Repeater>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
    OldValuesParameterFormatString="original_{0}"
    OnSelecting="ObjectDataSource1_Selecting" 
    SelectMethod="GetAlbums" 
    TypeName="Domain">
    <SelectParameters>
        <asp:Parameter Name="userName" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>

