<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
        .auto-style2 {
            font-size: medium;
        }
    </style>
</head>
<body>
    <h1 style="font-size: x-large">XYZ Corp Payroll System</h1>
    <form id="form1" runat="server">
    <div>
    
        <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/Default.aspx">Back to Home page</asp:HyperLink>
        <br />
        <br />
        <span class="auto-style1"><strong>Time Period:</strong></span>
        <asp:Label ID="timePeriod" runat="server"></asp:Label>
        <br />
        <h3>Employees and Consultants printout</h3>
        <asp:Label ID="employeeReport" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
    <div>
       <span class="auto-style1"><strong>Total W2 wages:</strong></span>&nbsp;
        <asp:Label ID="totalW2" runat="server"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp; <span class="auto-style1"><strong style="font-size: medium">Total Salaried Employees:</strong></span>&nbsp;
        <asp:Label ID="totalSE" runat="server"></asp:Label>
        <br />
        &nbsp;<span class="auto-style1"><strong style="font-size: medium">&nbsp; Total Hourly Employees:</strong></span>&nbsp;
        <asp:Label ID="totalHE" runat="server"></asp:Label>
        <br />
        <span class="auto-style1"><strong style="font-size: medium">&nbsp;&nbsp; Total Commissioned Employees:</strong></span>&nbsp;
        <asp:Label ID="totalCE" runat="server"></asp:Label>
        <br />
&nbsp;<span class="auto-style2"><strong>&nbsp; Average Salary Paid:</strong></span>
        <asp:Label ID="averageSalaryEmp" runat="server"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp; <span class="auto-style2"><strong>Lowest Paid Employee: </strong>
        <asp:Label ID="lowPaid" runat="server"></asp:Label>
        </span>
        <br />
&nbsp;&nbsp;&nbsp; <strong><span class="auto-style2">Highest Paid Employee: </span></strong>
        <asp:Label ID="highPaid" runat="server" style="font-size: medium"></asp:Label>
        <br />
        <br />
    </div>
    <div>
       <span class="auto-style1"><strong>Total 1099 wages:</strong></span>&nbsp;
        <asp:Label ID="total1099" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp; <span class="auto-style2"><strong>Lowest Paid Consultant:&nbsp;</strong></span>
        <asp:Label ID="lowPaidCons" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; <span class="auto-style2"><strong>Highest Paid Consultant:&nbsp;</strong></span>
        <asp:Label ID="highPaidCons" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; <strong><span class="auto-style2">Future Payments: </span></strong>&nbsp;<asp:Label ID="futurePayment" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; <strong><span class="auto-style2">Average Payment Consultant</span></strong>:
        <asp:Label ID="averagePaymentCons" runat="server"></asp:Label>
        <br />
    <br />

    </div>
    </form>
    </body>
</html>
