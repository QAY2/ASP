<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web.Beispiele._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="..\StyleSheet.css" />
    <title>Pizza Pizza</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Lecker Pizza! Verschiedene Beispielprogramme</h1>
        </div>
        <p>
            <asp:HyperLink ID="HyperLink2" runat="server"
                NavigateUrl="user_read.aspx">User Read</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink3" runat="server"
                NavigateUrl="user-insert.aspx">User Insert</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink4" runat="server"
                NavigateUrl="user-delete.aspx">User Delete</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink7" runat="server"
                NavigateUrl="user-aendern.aspx">User Ändern/Löschen</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink5" runat="server"
                NavigateUrl="user-select.aspx">User Selektieren</asp:HyperLink>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink6" runat="server"
                NavigateUrl="user-zaehlen.aspx">User Zählen</asp:HyperLink>
        </p>   
                <p>
            <asp:HyperLink ID="HyperLink8" runat="server"
                NavigateUrl="order-read.aspx">Order Read</asp:HyperLink>
        </p>

                <p>
            <asp:HyperLink ID="HyperLink9" runat="server"
                NavigateUrl="order-insert.aspx">Order Insert</asp:HyperLink>
        </p>
             <p>
            <asp:HyperLink ID="HyperLink1" runat="server"
                NavigateUrl="~/default.aspx">Home</asp:HyperLink>
        </p>
        <p>5.9.13</p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
</body>
</html>
