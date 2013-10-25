<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-aendern.aspx.cs" Inherits="web.beispiele.user_aendern" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link rel="stylesheet" type="text/css" href="..\StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <strong>Ändern und Löschen in User Tabelle
        </strong>
        <br /><br />
        </div>

    <div>
    
        <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="odsUsers" ForeColor="#333333" 
            GridLines="None" DataKeyNames="ID">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Address" HeaderText="Adresse" 
                    SortExpression="Address" />
                <asp:BoundField DataField="Distance" HeaderText="Entfernung" 
                    SortExpression="Distance" />
                <asp:CheckBoxField DataField="IsAdmin" HeaderText="Admin" SortExpression="IsAdmin" />
                <asp:BoundField DataField="Password" HeaderText="Passwort" ReadOnly="True" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsUsers" runat="server" 
            DataObjectTypeName="bll.clsUser" DeleteMethod="DeleteUser" 
            InsertMethod="InsertUser" SelectMethod="getAllUsers" 
            TypeName="bll.clsUserCollection" UpdateMethod="UpdateUser">
        </asp:ObjectDataSource>
        <br />
    
    </div>
            <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl="Default.aspx">Home</asp:HyperLink>
    
        <br />
            <hr />
        <br />
        Implementierung:<br />
&nbsp;mittels GridView <b>grdUser</b>, ObjectDataSource <b>odsUser</b>, BLL.<b>clsUserCollection<br />
        </b>
        <br />
        <i>grdUser</i>.DataSourceID = <i>odsUser</i><br />
        <i>grdUser</i>.DataKeyNames = ID (ID ist Key)&nbsp;&nbsp; // wichtig!!<br />
        <i>grdUser</i>: neue Spalte hinzufügen (CommandField <i>Edit</i> und <i>
        Delete</i>)
        <br />
        <br />
        <i>odsUser</i>.TypeName = BLL.<i>clsUserCollection</i><br />
        <i>odsUser</i>.SelectMethod = getAllUsers<br />
        <i>odsUser</i>.UpdateMethod = updateUser<br />
        <i>odsUser</i>.DeleteMethod = deleteUser<br />
        <i>odsUser</i>.InsertMethod = insertUser<br />
    
    </form>
</body>
</html>
