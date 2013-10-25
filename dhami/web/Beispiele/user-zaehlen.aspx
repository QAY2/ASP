<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-zaehlen.aspx.cs" Inherits="web.beispiele.user_zaehlen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pizza Pizza</title>
    <link rel="stylesheet" type="text/css" href="..\StyleSheet.css" />
</head>
<body>
    <p>
    
        <strong>Zählen in User Tabelle</strong></p>
    <form id="form1" runat="server">
    <div>
    
        Zählen, wieviele User wir in unserer TUser-Tabelle haben:</div>
    <p>
        Ergebnis: 
        <asp:Label ID="lblCount1" runat="server" Text="..." ForeColor="#CC3300"></asp:Label>
    </p>

    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Default.aspx">Home</asp:HyperLink>
    </form>
</body>
</html>
