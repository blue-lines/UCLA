<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1 style="font-size: x-large">XYZ Corp Payroll System</h1>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" Value="Home"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Input.aspx" Text="Input" Value="Input"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Report.aspx" Text="Report" Value="Report"></asp:MenuItem>
            </Items>
        </asp:Menu>
    <div>
    
        <br />
        This is the home page</div>
    </form>
</body>
</html>
