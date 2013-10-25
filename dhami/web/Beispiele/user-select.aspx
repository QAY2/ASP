<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-select.aspx.cs" Inherits="web.beispiele.user_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Auswahl eines Users</title>
    <link rel="stylesheet" type="text/css" href="..\StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <div>    
        Selektieren eines Users<br />
    </div>
    <div>   
        <br />
    entweder über DropDownBox oder über selektieren im GridView</div>
    
    </div>
    <asp:DropDownList ID="ddlUser" runat="server" DataSourceID="odsUsers" 
        DataTextField="Name" DataValueField="ID">
    </asp:DropDownList>
&nbsp;
    <asp:Button ID="btnDropDownSelect" runat="server" 
        onclick="btnDropDownSelect_Click" Text="aus DropDownList Auswählen" />
    <br />
    <asp:ObjectDataSource ID="odsUsers" runat="server" SelectMethod="getAllUsers" 
        TypeName="bll.clsUserCollection"></asp:ObjectDataSource>
    <br />
    <asp:GridView ID="grdUsers" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="odsUsers" ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="grdUsers_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="Adresse" SortExpression="Address" />
            <asp:BoundField DataField="Distance" HeaderText="Entfernung" SortExpression="Active" />
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
    <br />
    <asp:Label ID="lblMsg" runat="server" Text="..."></asp:Label>
    <br />
            <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
    
        <br />
            <hr />
                    <br />
        <em><span class="style3">Implementierung mittels DropDownList </span>
    <span class="style4">ddlUser</span><span class="style3">, GridView </span>
    <span class="style4">grdUser</span><span class="style3">, ObjectDataSource 
    </span><span class="style4">odsUser</span><span class="style3">, BLL.</span><span 
        class="style4">clsUserCollection</span><span class="style3">, 
            Queries </span><span class="style4">QGetAllUsers</span><span 
        class="style3"> und </span><span class="style4">QGetUserByID</span><span 
        class="style3">, sowie Tabelle </span><span class="style4">TUser</span><br 
        class="style3" />
        
        <br class="style3" />
            <span class="style3">ddlUser.DataSourceID = odsUser</span><br 
        class="style3" />
            <span class="style3">ddlUser.DataTextField = Name // was in DDL angezeigt wird</span><br 
        class="style3" />
            <span class="style3">ddlUser.DataValueField = ID&nbsp; // Attribut, welches als selektierter 
            Wert weitergegeben wird. In Methode </span><span class="style4">btnDDLUser_Click()</span><span 
        class="style3"> Zugriff mittels </span><span class="style4">ddlUser.SelectedValue</span><br 
        class="style3" />
            <br class="style3" />
            <span class="style3">grdUser.DataSourceID = odsUser</span><br 
        class="style3" />
            <span class="style3">grdUser: Select aktiviert, entsprechendes Klick-Ereignis ruft Methode 
    </span></em> <b>
            <em><span class="style3">grdUser_SelectedIndexChanged()</span><br 
        class="style3" />
            </em>
            </b>
            <em>
            <br class="style3" />
            <span class="style3">odsUser.TypeName = bll.clsUserCollection</span><br 
        class="style3" />
            <span class="style3">odsUser.SelectMethod = getAllUser
            </span></em>
    </form>
</body>
</html>
