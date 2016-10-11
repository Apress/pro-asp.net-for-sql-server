<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="PageView.aspx.cs" Inherits="PageView" Title="Untitled Page" %>

<%@ Register Src="Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID=pnlPublic runat=server>
   <%if(SiteUtility.UserCanEdit()){ %>
   <div style="float:right;border:1px solid gainsboro;font-size:8pt;padding:10px;margin-top:50px">
        <center><b>Admin</b></center>
        <table cellpadding=5 width=80>
        
            <tr>
                <td width=10><img src='<%=Page.ResolveUrl("~/images/icons/edit.gif") %>' /></td>
                <td><asp:LinkButton ID=lnkEdit runat=server Text="Edit" OnClick="lnkEdit_Click" CausesValidation=false></asp:LinkButton></td>
            </tr>
            <tr>
                <td width=10><img src='<%=Page.ResolveUrl("~/images/icons/add.gif") %>' /></td>
                <td><asp:LinkButton ID=lnkNewPage runat=server Text="New" OnClick="lnkNewPage_Click" CausesValidation=false></asp:LinkButton></td>
            </tr>
            <tr>
                <td width=10><img src='<%=Page.ResolveUrl("~/images/icons/addressbook.gif") %>' /></td>
                <td><a href='<%=Page.ResolveUrl("~/admin/cmspagelist.aspx") %>'>Page List</a></td>
            </tr>
        </table>
    </div>
    <%}%>
    <div>
        <h1><%=thisPage.Title%></h1>
        
        <div class=pagesummary><%=thisPage.Summary %></div>
        <%=thisPage.Body %>
        <div class=lastupdated>
            <i>Last updated by <%=thisPage.ModifiedBy%> on <%=thisPage.ModifiedOn.ToShortDateString() %></i>
        </div>
    </div>
</asp:Panel>



<asp:Panel ID=pnlEdit runat=server>



    <h1><asp:Label ID=editorTitle runat=server></asp:Label></h1>
        <uc1:ResultMessage ID="ResultMessage1" runat="server" />
    
    <div>
        <p>
        <b>Title</b><br />
        <asp:TextBox ID=txtTitle runat=server Width="461px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator><br />
        <i>This shows at the top of each page.</i>
        </p>
        <p>
        <b>Menu Title</b><br />
        <asp:TextBox ID=txtMenuTitle runat=server Width="200px"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMenuTitle"
                ErrorMessage="Required" Display="Dynamic"></asp:RequiredFieldValidator><br /><i>This is a simple title for the page, to be used with menuing</i>
        </p>
        <p>
        <b>Location</b><br />
            <asp:ListBox ID=lstHierarchy runat=server Height="120px" Width="350px" Enabled="False"></asp:ListBox>
    
        </p>
        <p>
          <b>Parent Page</b><br />
          <asp:DropDownList ID=ParentID runat=server></asp:DropDownList>
            <asp:Button ID="btnSetParent" runat="server" Text="Set" OnClick="btnSetParent_Click" /></p>
        
 
        <p> 
        <b>Summary</b><br />
        <asp:TextBox ID=txtSummary runat=server Width="460px" Height="97px" TextMode="MultiLine"></asp:TextBox>
         <br /><i>Used for searches and summary listings - create a quick summary of what this page is about</i>
        </p>
        <p>
        <b>Keywords</b><br />
        <asp:TextBox ID=txtKeywords runat=server Width="460px" Height="97px" TextMode="MultiLine"></asp:TextBox>
         <br /><i>These values are put into the META tag</i>
        </p>

        <p>
        <b>Roles</b><br />
            <asp:CheckBoxList runat=server ID=chkRoles></asp:CheckBoxList>
        </p>
        <p>

        <b>Body</b><br />
        <fck:FCKeditor id="Body" BasePath="~/FCKeditor/" runat="server"  Height="700" Width="800"/>
        </p>
        <p>
            <asp:Button ID=btnSave runat=server Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID=btnCancel runat=server Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button ID=btnDelete runat=server Text="Delete" OnClick="btnDelete_Click" />
           
        </p>
    </div>

    <script>
    function CheckDelete(){
    		
	    return confirm("Delete this page? This action cannot be undone...");

    }

    </script>
</asp:Panel>

</asp:Content>

