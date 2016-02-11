using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Report : System.Web.UI.Page
{
    // Global variables 
    // If data has already been loaded from XML files
    private static bool loaded = false;
    // Lists of objects 
    private static List<CommissionEmployee> listCE = new List<CommissionEmployee>();
    private static List<Consultant> listCons = new List<Consultant>();
    private static List<HourlyEmployee> listHE = new List<HourlyEmployee>();
    private static List<SalariedEmployee> listSE = new List<SalariedEmployee>();
    // Sorted Dictionary to sort all employees;
    SortedDictionary<int, string> listEmployee = new SortedDictionary<int, string>();
    // List of XML files to load
    private static string[] XMLFileList = { "CEmployees.xml", "Consultants.xml", "HEmployees.xml", "SEmployees.xml" };
    // Time period date range
    private static DateTime lowRange = new DateTime(2014, 1, 14), upRange = new DateTime(2014, 1, 17);

    // Load data from XML files to object list
    protected void createList(string xmlFilename)
        {
            DataSet ds = new DataSet();
            string result;
            string[] objList;
            ds.ReadXml(Server.MapPath("App_Data/" + xmlFilename));

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    result = (string.Join(", ", row.ItemArray));
                    objList = result.Split(',');

                    switch (xmlFilename)
                    {
                        case "CEmployees.xml":
                            listCE.Add(new CommissionEmployee(objList[1], objList[2], objList[0], Convert.ToDateTime(objList[3]), 
                                Convert.ToInt32(objList[5]), Convert.ToDouble(objList[6]), Convert.ToInt32(objList[4])));
                            break;
                        case "Consultants.xml":
                            listCons.Add(new Consultant(objList[0], objList[1], Convert.ToDateTime(objList[2]), 
                                Convert.ToDateTime(objList[3]), Convert.ToInt32(objList[4])));
                            break;
                        case "HEmployees.xml":
                            listHE.Add(new HourlyEmployee(objList[1], objList[2], objList[0], Convert.ToDateTime(objList[3]),
                                Convert.ToDouble(objList[4]), Convert.ToInt32(objList[5])));
                            break;
                        case "SEmployees.xml":
                            listSE.Add(new SalariedEmployee(objList[1], objList[2], objList[0], Convert.ToDateTime(objList[3]),
                                Convert.ToInt32(objList[4])));
                            break;
                    }
                }
            }
        }

    // Print raw data from object lists
    protected string printReport()
        {
            string printRes = null;
            foreach (SalariedEmployee SE in listSE)
            {
                //printRes += SE.ToString() + "<br/>";
                listEmployee.Add(Convert.ToInt32(SE.getSalary()), SE.ToString() + "<br/>");
            }
            foreach (HourlyEmployee HE in listHE)
            {
                //printRes += HE.ToString() + "<br/>";
                listEmployee.Add(Convert.ToInt32(HE.getSalary()), HE.ToString() + "<br/>");
            }
            foreach (CommissionEmployee CE in listCE)
            {
                //printRes += CE.ToString() + "<br/>";
                listEmployee.Add(Convert.ToInt32(CE.getSalary()), CE.ToString() + "<br/>");
            }

            // Sorting employees
            foreach (var employ in listEmployee.OrderByDescending(key => key.Key))
            {
                printRes += employ.Value;
            }
            // Sorting consultants
            listCons = listCons.OrderByDescending(o => o.payment).ToList();
            foreach (Consultant Cons in listCons) printRes += Cons.ToString() + "<br/>";

            return printRes;
        }

    // Total W2 wages
    protected double totalW2Salary()
    {
        double printRes = 0;
        printRes += totalSEPay();
        printRes += totalHEPay();
        printRes += totalCEPay();

        return printRes;
    }

    // Total 1099 wages
    protected string total1099Salary()
    {
        int printRes = 0;
        foreach (Consultant Cons in listCons)
        {
            if (Cons.terminationDate.Date >= lowRange.Date && Cons.terminationDate.Date <= upRange.Date)
                printRes += Cons.payment;
        }

        return printRes.ToString();
    }

    // Total Salaried Employees
    protected double totalSEPay()
    {
        double printRes = 0;
        foreach (SalariedEmployee SE in listSE)
            printRes += SE.getSalary();

        return printRes;
    }

    // Total Hourly Employees
    protected double totalHEPay()
    {
        double printRes = 0;
        foreach (HourlyEmployee HE in listHE)
            printRes += HE.getSalary();

        return printRes;
    }

    // Total Commissioned Employees
    protected double totalCEPay()
    {
        double printRes = 0;
        foreach (CommissionEmployee CE in listCE)
            printRes += CE.getSalary();

        return printRes;
    }

    // Most paid Employee
    protected string mostPaidEmployee()
    {
        string resEmployee = null;
        double resSalary = 0;
        foreach (SalariedEmployee SE in listSE)
        {
            if (resSalary < SE.getSalary())
            {
                resSalary = SE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    SE.employeeID, SE.firstName + " " + SE.lastName, SE.getSalary().ToString());
            }
        }
        foreach (HourlyEmployee HE in listHE)
        {
            if (resSalary < HE.getSalary())
            {
                resSalary = HE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    HE.employeeID, HE.firstName + " " + HE.lastName, HE.getSalary().ToString());
            }
        }
        foreach (CommissionEmployee CE in listCE)
        {
            if (resSalary < CE.getSalary())
            {
                resSalary = CE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    CE.employeeID, CE.firstName + " " + CE.lastName, CE.getSalary().ToString());
            }
        }
        return resEmployee;
    }

    // Lowest paid Employee
    protected string lowPaidEmployee()
    {
        string resEmployee = null;
        double resSalary = 0;
        foreach (SalariedEmployee SE in listSE)
        {
            if (resSalary == 0) resSalary = SE.getSalary(); // First salary to compare
            if (resSalary > SE.getSalary())
            {
                resSalary = SE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    SE.employeeID, SE.firstName + " " + SE.lastName, SE.getSalary().ToString());
            }
        }
        foreach (HourlyEmployee HE in listHE)
        {
            if (resSalary == 0) resSalary = HE.getSalary();
            if (resSalary > HE.getSalary())
            {
                resSalary = HE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    HE.employeeID, HE.firstName + " " + HE.lastName, HE.getSalary().ToString());
            }
        }
        foreach (CommissionEmployee CE in listCE)
        {
            if (resSalary == 0) resSalary = CE.getSalary();
            if (resSalary > CE.getSalary())
            {
                resSalary = CE.getSalary();
                resEmployee = string.Format("{0}, {1}, {2:C}",
                    CE.employeeID, CE.firstName + " " + CE.lastName, CE.getSalary().ToString());
            }
        }
        return resEmployee;
    }

    // Most paid Consultant
    protected string mostPaidConsultant()
    {
        string resConsultant = null;
        int resSalary = 0;
        foreach (Consultant Cons in listCons)
        {
            if ((resSalary < Cons.payment) && (Cons.terminationDate.Date >= lowRange.Date && Cons.terminationDate.Date <= upRange.Date))
            {
                resSalary = Cons.payment;
                resConsultant = string.Format("{0}, {1:C}",
                    Cons.firstName + " " + Cons.lastName, Cons.payment.ToString());
            }
        }
       
        return resConsultant;
    }

    // Lowest paid Consultant
    protected string lowPaidConsultant()
    {
        string resConsultant = null;
        int resSalary = 0;
        foreach (Consultant Cons in listCons)
        {
            if(Cons.terminationDate.Date >= lowRange.Date && Cons.terminationDate.Date <= upRange.Date){
                if (resSalary == 0)
                {
                    resSalary = Cons.payment; // First payment to compare
                    resConsultant = string.Format("{0}, {1:C}",
                        Cons.firstName + " " + Cons.lastName, Cons.payment.ToString());
                }
                if (resSalary > Cons.payment) 
                {
                    resSalary = Cons.payment;
                    resConsultant = string.Format("{0}, {1:C}",
                        Cons.firstName + " " + Cons.lastName, Cons.payment.ToString());
                }
            }
        }

        return resConsultant;
    }

    // Future payment for Consultants
    protected string futurePaidConsultant()
    {
        string resConsultant = null;
        foreach (Consultant Cons in listCons)
        {
            if (Cons.terminationDate.Date > upRange.Date)
            {
                resConsultant += string.Format("{0}, {1:C} </br>",
                    Cons.firstName + " " + Cons.lastName, Cons.payment.ToString());
            }
        }

        return resConsultant;
    }

    // Average Salary for Employees
    protected string averageSalaryEmployee()
    {
        string printRes = null;
        double totalSalary = 0;
        int numEmployee = 0;
        foreach (var employ in listEmployee)
        {
            totalSalary += employ.Key;
            numEmployee++;
        }
        printRes = (totalSalary / numEmployee).ToString();
        return printRes;
    }

    // Average Payment for Consultants
    protected string averagePaymentConsultant()
    {
        string printRes = null;
        double totalSalary = 0;
        int numConsultant = 0;
        foreach (Consultant cons in listCons)
        {
            totalSalary += cons.getSalary();
            numConsultant++;
        }
        printRes = (totalSalary / numConsultant).ToString("#.###");
        return printRes;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            // only load the input files once
            if (!loaded)
            {
                foreach (string XMLFile in XMLFileList)
                    createList(XMLFile);
                loaded = true;
            }

            timePeriod.Text = lowRange.ToShortDateString() + " to " + upRange.ToShortDateString();
            employeeReport.Text = printReport();
            totalW2.Text = " $ " + totalW2Salary().ToString();   // use string.format {0:C} doesnt work??
            totalSE.Text = " $ " + totalSEPay().ToString();
            totalHE.Text = " $ " + totalHEPay().ToString();
            totalCE.Text = " $ " + totalCEPay().ToString();
            lowPaid.Text = lowPaidEmployee();
            highPaid.Text = mostPaidEmployee();
            total1099.Text = " $ " + total1099Salary();
            lowPaidCons.Text = lowPaidConsultant();
            highPaidCons.Text = mostPaidConsultant();
            futurePayment.Text = futurePaidConsultant();
            averageSalaryEmp.Text = " $ " + averageSalaryEmployee();
            averagePaymentCons.Text = " $ " + averagePaymentConsultant();

    }
}

