using ds_ProductsTableAdapters;
using ds_StoreTableAdapters;
using ds_ReportTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class tellepet_reilmajb_Assignment07_Default : System.Web.UI.Page
{
    private static System.Data.SqlClient.SqlConnection conn;
    private static SqlCommand comm;
    private static SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenConnection();
            //Populating the Product dropdown.
            tProductTableAdapter productTypeAdapter = new tProductTableAdapter();
            ds_Products.tProductDataTable products = productTypeAdapter.GetData();
            /*
             * Ref for below code: http://stackoverflow.com/questions/1143639/binding-multiple-fields-to-listbox-in-asp-net/
             * In all honesty not entirely sure how this works...
             * Is this kinda like a Lambda Function?
             * Specifically looked for this though to keep formatting out of the data layer.
             */
            EnumerableRowCollection productData = from product in products
                                                  select new
                                                  {
                                                      Name = product.Name + " - " + product.Description + " :by " + product.Manufacturer,
                                                      Id = product.ProductID
                                                  };
            //end code I don't fully understand
            //The rest is just normal data binding.
            ddProducts.DataSource = productData;
            ddProducts.DataTextField = "Name";
            ddProducts.DataValueField = "Id";
            ddProducts.DataBind();

            tStoreTableAdapter storeTypeAdapter = new tStoreTableAdapter();
            ds_Store.tStoreDataTable storeDataTable = storeTypeAdapter.GetData();
            cblStores.DataTextField = "Store";
            cblStores.DataValueField = "StoreID";
            cblStores.DataSource = storeDataTable;
            cblStores.DataBind();
            cblStores.SelectedIndex = 0;
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        string startDate = Convert.ToString(calStartDate.SelectedDate);
        string endDate = Convert.ToString(calEndDate.SelectedDate);
        string productID = ddProducts.SelectedValue;
        string minQty = txtMinQty.Text;
        string maxQty = txtMaxQty.Text;        
        List<List<string>> reportData = new List<List<string>>();
        List<string> reportCell = new List<string>();
        string storesSelected = "";

        for (int i = 0; i < cblStores.Items.Count; i++)
        {
            if (cblStores.Items[i].Selected == true)
            {
                storesSelected += cblStores.Items[i].Text + " OR";
            }
            storesSelected.Remove(storesSelected.Length - 1, 2);
        }
        string query = buildQuery(startDate, endDate, productID, storesSelected);
        comm = new SqlCommand(query, conn);
        try { reader.Close(); } catch (Exception ex) { }
        reader = comm.ExecuteReader();

        while (reader.Read())
        {
            if (reader.GetInt32(2) >= Convert.ToInt32(txtMinQty.Text) && reader.GetInt32(2) <= Convert.ToInt32(txtMaxQty.Text))
            {
                reportData.Add(new List<string>() { reader.GetString(0), reader.GetString(1), ddProducts.SelectedItem.Text, Convert.ToString(reader.GetInt32(2)) });
            }
        }
        Session["Data"] = reportData;
        Response.Redirect("Report.aspx");
    }

    protected string buildQuery(string startDate, string endDate, string productID, string storesSelected)
    {
        string query = "SELECT tStoreID, tStore.Store, tStore.Address1, SUM(tTransactionDetail.QtyOfProduct) AS ProductQty FROM tTransaction INNER JOIN tStore ON tTransaction.StoreID = tStore.StoreID INNER JOIN" +
            " tTransactionDetail ON tTransaction.TransactionID = tTransactionDetail.TransactionID INNER JOIN tProduct INNER JOIN tName ON tProduct.NameID = tName.NameID INNER JOIN" +
            " tManufacturer ON tProduct.ManufacturerID = tManufacturer.ManufacturerID ON tTransactionDetail.ProductID = tProduct.ProductID INNER JOIN tTransactionType ON" +
            " tTransaction.TransactionTypeID = tTransactionType.TransactionTypeID" +
            " WHERE(tTransaction.DateOfTransaction BETWEEN '" + startDate + "' AND '" + endDate + "') AND (tTransactionType.TransactionTypeID = 1) AND" +
            " (tProduct.ProductID = " + productID + ") GROUP BY tStore.Store, tStore.Address1 AND (tStore.StoreID = " + storesSelected + ")";
        return query;
    }

    private void OpenConnection()
    {
        System.Configuration.ConnectionStringSettings strConn;
        strConn = ReadConnectionString();
        // Console.WriteLine(strConn.ConnectionString);

        conn = new System.Data.SqlClient.SqlConnection(strConn.ConnectionString);

        // This could go wrong in so many ways...
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            // Miserable error handling...
            Response.Write(ex.Message);
        }
    }
    private System.Configuration.ConnectionStringSettings ReadConnectionString()
    {
        String strPath;
        strPath = HttpContext.Current.Request.ApplicationPath + "/web.config";
        System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(strPath);

        System.Configuration.ConnectionStringSettings connString = null;
        if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
        {
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["GroceryStoreSimulatorConnectionString"];
        }
        return connString;
    }
}