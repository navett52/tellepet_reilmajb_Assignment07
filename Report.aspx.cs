using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{

    List<List<string>> reportData = new List<List<string>>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Data"] is List<List<string>>)
            {
                reportData = (List<List<string>>)Session["Data"];
            }
            int i = 1;
            foreach (List<string> data in reportData)
            {
                litReport.Text += "<div class=\"reportCell\""; //Open reportCell
                litReport.Text += "<h1>Store" + i + "</h1>";
                litReport.Text += "<div class=\"store\">Store: " + data[0] + "</div>";
                litReport.Text += "<div class=\"address\">Address: " + data[1] + "</div>";
                litReport.Text += "<div class=\"product\">Product Info: " + data[2] + "</div>";
                litReport.Text += "<div class=\"qty\">Quantity of Product Sold over Date Range: " + data[3] + "</div>";
                litReport.Text += "</div>"; //Close reportCell
                i++;
            }
        }
    }
}
