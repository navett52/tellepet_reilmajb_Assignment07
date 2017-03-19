using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tellepet_reilmajb_Assignment07_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tProductTableAdapter productTypeAdapter = new tProductTableAdapter();

            //Populating the Transaction Type drop down using the databse.
            ds_Products.tProductDataTable products = productTypeAdapter.GetData();
            ddProducts.DataTextField = "TransactionType";
            ddProducts.DataValueField = "TransactionTypeID";
            ddProducts.DataSource = products;
            ddProducts.DataBind();
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

    }

    protected string buildQuery(DateTime startDate, DateTime endDate, int minQty, int maxQty, List<string> stores)
    {
        string query = "";

        

        return query;
    }
}