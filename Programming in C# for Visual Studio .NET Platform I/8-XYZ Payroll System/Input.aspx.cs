using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Input : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddlXMLFiles_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        ds.ReadXml(Server.MapPath("App_Data/" + ddlXMLFiles.SelectedItem.Value.ToString()));
        grdViewEmployees.DataSource = ds;
        grdViewEmployees.DataBind();
    }
}