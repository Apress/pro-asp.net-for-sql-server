<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Chapter 3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width: 700px; font-size: 14px; font-family: Arial, Verdana, Sans-Serif;">
    <h3>Prepare the Database:</h3>
    <ol>
        <li>Use SQL Server Management Studio to create a database called Chapter04</li>
        <li>Ensure the Database project references the <code>Chapter04</code> by default</li>
        <li>Run the scripts in the <code>Tables</code> folder in the Database project</li>
        <li>Run the Add scripts in the <code>Constraints</code> folder in the Database project</li>
        <li>Run all of the scripts in the <code>Stored Procedures</code> folder in the Database project</li>
    </ol>
    <p>
        The Website and Console applications are configured to connect with a SQL Server database
        over a trusted connection.
        If you are instead using a SQL Express database you must adjust the connection string.
        Change <code>(local)</code> to <code>.\SQLEXPRESS</code> in the <code>Web.config</code>
        in the Website project and the <code>app.config</code> in the Console Application as 
        needed.</p>
    <h3>
        Generate the Data:</h3>
    <ol>
        <li>In the <code>Solution Explorer</code> right-click the <code>ConsoleApplication</code> project and select <code>Set
            as Startup Project</code></li>
        <li>Click <code>Debug</code> on the file menu and select <code>Start Without Debugging</code></li>
    </ol>
    <p>
        The Console Application will generate 10,000 rows into the Person table with random
        names, birth dates and associated locations. You can change the number of
        generated records by changing the call to RegenerateData in Program.cs. You
        can re-run the Console Application multiple times. Each time it runs the existing
        data will be replaced completely with the newly generated data.</p>
    <h3>View the Website:
        </h3>
    <ol>
    <li>In the <code>Solution Explorer</code>, right-click Default.aspx in the Website project and
        select <code>View in Browser</code></li>
    </ol>
</div>
</asp:Content>
