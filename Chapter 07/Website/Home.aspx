<%@ Page Language="C#" MasterPageFile="~/FavoriteLink.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" Title="Favorite Link: Home" %>

<asp:Content ID="Content1" runat="server" 
    ContentPlaceHolderID="MainContentPlaceHolder">
    <div id="HomeContent">
        <div class="tagCloud" style="float: right; width: 150px;">
            <h3 class="Title">Tags</h3>
            <fl:TagCloudControl ID="tagCloud" runat="server" 
                OnTagSelected="tagCloud_OnTagSelected" />
        </div>
        <div id="Links">
            <fl:TaggedLinksControl 
                ID="taggedLinks" runat="server" 
                Visible="false" />
            
            <fl:LinksControl 
                ID="lcToday" runat="server" 
                Title="Today" 
                EndDaysBack="0" 
                StartDaysBack="1" 
                TitleVisible="true" />
                
            <fl:LinksControl 
                ID="lcThisWeek" runat="server" 
                Title="This Week" 
                EndDaysBack="1" 
                StartDaysBack="7"
                TitleVisible="true" />
                
            <fl:LinksControl 
                ID="lcThisMonth" runat="server" 
                Title="This Month" 
                EndDaysBack="8" 
                StartDaysBack="31"
                TitleVisible="true" />
        </div>
    </div>
</asp:Content>
