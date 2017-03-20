using ds_ProductsTableAdapters;
using ds_StoreTableAdapters;
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
            ds_Store.tStoreDataTable stores = storeTypeAdapter.GetData();

            EnumerableRowCollection storeData = from store in stores
                                                  select new
                                                  {
                                                      Name = store.Store,
                                                      Id = store.StoreID
                                                  };
            cblStores.DataSource = storeData;
            cblStores.DataTextField = "Name";
            cblStores.DataValueField = "Id";
            cblStores.DataBind();
        }
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {

    }

    protected string buildQuery(DateTime startDate, DateTime endDate, int minQty, int maxQty, List<string> stores)
    {
        string query = "SELECT SUM(tTransactionDetail.QtyOfProduct) AS Expr1 FROM tTransaction INNER JOIN tStore ON tTransaction.StoreID = tStore.StoreID INNER JOIN" + 
            " tTransactionDetail ON tTransaction.TransactionID = tTransactionDetail.TransactionID INNER JOIN tProduct INNER JOIN tName ON tProduct.NameID = tName.NameID INNER JOIN" + 
            " tManufacturer ON tProduct.ManufacturerID = tManufacturer.ManufacturerID ON tTransactionDetail.ProductID = tProduct.ProductID INNER JOIN tTransactionType ON" + 
            " tTransaction.TransactionTypeID = tTransactionType.TransactionTypeID" + 
            " WHERE(tTransaction.DateOfTransaction BETWEEN '01/01/2017' AND '12/31/2018') AND(tTransactionType.TransactionTypeID = 1) AND" + 
            " (tStore.Store IN('001001', 'Amelia', 'Anderson', 'Ankorage')) AND (tProduct.ProductID = 3)";

        

        return query;
    }
}