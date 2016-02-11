<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-size: large; font-weight: 700">
    
        Main Page<br />
        <br />
        <span class="auto-style1">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Building.aspx" style="font-size: medium">Building page</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Equipment.aspx" style="font-size: medium">Equipment page</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Employee.aspx" style="font-size: medium">Employee page</asp:HyperLink>
        </span>
    
    </div>
    </form>
</body>
</html>
