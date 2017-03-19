using ds_ProductsTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
            //Populating the Transaction Type drop down using the databse.
            tProductTableAdapter productTypeAdapter = new tProductTableAdapter();

            ds_Products.tProductDataTable products = productTypeAdapter.GetData();

            List<string> productData = new List<string>();
            foreach (DataRow dataRow in products.Rows)
            {
                productData.Add(dataRow["Manufacturer"].ToString() + " : " + dataRow["Name"].ToString() + "- " + dataRow["Description"].ToString());
            }
            ddProducts.DataSource = productData;

            //ddProducts.DataTextField = "Name";
            ddProducts.DataValueField = "ProductID";
            //ddProducts.DataSource = products;
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