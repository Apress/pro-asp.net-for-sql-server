<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Chapter 5: SQL Providers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
<div style="width: 700px; font-size: 14px; font-family: Arial, Verdana, Sans-Serif;">
    <h3>Prepare the Database:</h3>
    <ol>
        <li>Use SQL Server Management Studio to create a database called Chapter05</li>
        <li>Ensure the Database project references the <code>Chapter05</code> by default</li>
        <li>Run the scripts in the <code>Table Scriptss</code> folder in the PhotoAlbumDatabase
            project</li>
        <li>Run the scripts in the <code>Stored Procedures Scripts</code> folder in the PhotoAlbumDatabase
            project</li>
        <li>Run the AddConstraints.sql script in the Constraints folder in the PhotoAlbumDatabase
            project</li>
        <li>Run the scripts in the <code>Table Scripts</code> folder in the SiteMapDatabase
            project</li>
        <li>Run the scripts in the <code>Stored Procedures Scripts</code> folder in the SiteMapDatabase
            project</li>
    </ol>
    <h3>Add the Provider Services:</h3>
    <ol>
        <li>Run <code>Add Provider Services.cmd</code> in the root folder</li>
        <li>Run <code>Add SQL Cache Dependencies.cmd</code> in the root folder</li>
    </ol>
    <p>
        The Website and Console applications are configured to connect with a SQL Server database
        over a trusted connection.
        If you are instead using a SQL Express database you must adjust the connection string.
        Change <code>(local)</code> to <code>.\SQLEXPRESS</code> in the <code>Web.config</code>
        in the Website project and the <code>app.config</code> in the Console Application as 
        needed.</p>
    <h3>View the Website:
        </h3>
    <ol>
    <li>In the <code>Solution Explorer</code>, right-click Default.aspx in the Website project and
        select <code>View in Browser</code></li>
        <li>Create a new account which will log you in the first time</li>
    <li>Go to the Albums page and click the <code>Import Default Flickr Albums</code> button</li>
    </ol>
</div>

    <asp:HyperLink ID="hlPhotoAlbums" runat="server" NavigateUrl="~/Albums/Default.aspx" CssClass="Big">Go to Albums</asp:HyperLink>
</asp:Content>
