<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order-read.aspx.cs" Inherits="web.Beispiele.order_read" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <link rel="stylesheet" type="text/css" href="..\StyleSheet.css" />
    <title>Pizza - Order Read</title>
</head>
<body>
    <form id="form1" runat="server">
   
        <h1>Lecker Pizza Admin: Lesen Order Tabelle</h1>
        <p></p>

    <asp:GridView ID="grdOrders" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" style="font-family: Arial, Helvetica, Sans-Serif" 
        DataSourceID="odsOrders" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="ProductId" HeaderText="ProductId" SortExpression="ProductId" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" 
                SortExpression="UserId" />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" 
                SortExpression="OrderDate" />
            <asp:BoundField DataField="OrderSize" HeaderText="OrderSize" SortExpression="OrderSize" />
            <asp:BoundField DataField="OrderExtras" HeaderText="OrderExtras" SortExpression="OrderExtras" />
            <asp:BoundField DataField="OrderCount" HeaderText="OrderCount" SortExpression="OrderCount" />
            <asp:BoundField DataField="OrderSum" HeaderText="OrderSum" SortExpression="OrderSum" />
            <asp:CheckBoxField DataField="OrderDelivery" HeaderText="OrderDelivery" SortExpression="OrderDelivery" />
            <asp:BoundField DataField="OrderStorno" HeaderText="OrderStorno" SortExpression="OrderStorno" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#4b6c9e" Font-Bold="False" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <div>
    
        <asp:ObjectDataSource ID="odsOrders" runat="server" SelectMethod="getAllOrders" 
            TypeName="bll.clsOrderCollection"></asp:ObjectDataSource>
    
        <br />
        <asp:GridView ID="grdOrderExtended" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="odsOrdersExtended" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="OrderSize" HeaderText="OrderSize" SortExpression="OrderSize" />
                <asp:BoundField DataField="OrderExtras" HeaderText="OrderExtras" SortExpression="OrderExtras" />
                <asp:BoundField DataField="OrderCount" HeaderText="OrderCount" SortExpression="OrderCount" />
                <asp:BoundField DataField="OrderSum" HeaderText="OrderSum" SortExpression="OrderSum" />
                <asp:CheckBoxField DataField="OrderDelivery" HeaderText="OrderDelivery" SortExpression="OrderDelivery" />
                <asp:BoundField DataField="OrderStorno" HeaderText="OrderStorno" SortExpression="OrderStorno" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <asp:ObjectDataSource ID="odsOrdersExtended" runat="server" SelectMethod="getAllOrdersExtended" TypeName="bll.clsOrderCollection"></asp:ObjectDataSource>
        <br />
    
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
    
    </div>
    </form>
        <div>
        <hr />
        <br />
        <i>Implementierung:<br />
&nbsp;mittels GridView <b>grdOrder</b>, ObjectDataSource <b>odsOrder</b>, BLL.<b>clsOrderCollection</b>, Query <b>QGetAllOrders</b>, 
        Tabelle <b>TOrder<br />
        </b></i>
        <br />
        <i>grdOrder.DataSourceID = odsOrder<br />
        odsOrder.TypeName = bll.clsOrderCollection<br />
        odsOrder.SelectMethod = getAllOrders<br />
            <br />
            2. Tabelle: dasselbe mit BLL.clsOrderExtended</i></div>
 
</body>
</html>
