<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Input.aspx.cs" Inherits="Input" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="font-size: x-large">XYZ Corp Payroll System</h1>
    
    </div>
        <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/Default.aspx">Back to Home page</asp:HyperLink>
        <br />
        <br />
        <h2 class="auto-style1">Input Data</h2>
        <br />
        <asp:DropDownList ID="ddlXMLFiles" runat="server" Height="21px" OnSelectedIndexChanged="ddlXMLFiles_SelectedIndexChanged" Width="199px">
            <asp:ListItem Value="HEmployees.xml">Hourly Employees</asp:ListItem>
            <asp:ListItem Value="SEmployees.xml">Salary Employees</asp:ListItem>
            <asp:ListItem Value="CEmployees.xml">Commission Employees</asp:ListItem>
            <asp:ListItem Value="Consultants.xml">Consultants</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="btnLoad" runat="server" Height="29px" OnClick="btnLoad_Click" Text="Load" Width="96px" />
        <br />
        <br />
        <br />
        <asp:GridView ID="grdViewEmployees" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>
