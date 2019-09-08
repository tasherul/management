using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.Return
{
    public partial class Purchase_Add : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        protected void Page_Load(object sender, EventArgs e)
        {
            //session check and Verify the page authrity
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                {
                    showProduct();//show the product in dorpdownlist
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        /*  ---------------------------------
         *  Show product in drop down list
         *  configuration is connection
         * 
        -------------------------------------*/
        private void showProduct()
        {
            ddlProduct.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name,p_id from ProductAdd";
            con.Open();
            ddlProduct.Items.Add(new ListItem("Select Product", "0"));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["p_id"].ToString();
                ddlProduct.Items.Add(li);
            }
            con.Close();
        }

        protected void ddlProduct_TextChanged(object sender, EventArgs e)
        {
            if(ddlProduct.SelectedValue!="0")
            {
                string c_id = ddlProduct.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT
	s.s_id,s.stock_id, s.ProductName,BuyQuantity,BuyingPrice,Amount,Unit,l.InputDate,l.Invoice,
	case
	when l.c_id=(select c_id from Supplier where l.c_id=c_id) then 
	(select name from dbmanagement.dbo.Supplier where l.c_id=c_id)
	else 'NULL'
	end as SupplierName
  FROM Stock as s,dbmanagement.dbo.StockList as l where s.stock_id=l.stock_id
  and s.p_id=" + c_id;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                string show = "";int i = 1; ShowData.Controls.Clear();
                while (dr.Read())
                {
                    string s_id = dr["s_id"].ToString();
                    string stock_id = dr["stock_id"].ToString();
                    string ProductName = dr["ProductName"].ToString();
                    string BuyQuantity = dr["BuyQuantity"].ToString();
                    string BuyingPrice = dr["BuyingPrice"].ToString();
                    string Amount = dr["Amount"].ToString();
                    string Unit = dr["Unit"].ToString();
                    string InputDate = dr["InputDate"].ToString();
                    string SupplierName = dr["SupplierName"].ToString();
                    string Invoice = dr["Invoice"].ToString();

                    show += string.Format(@"<tr>
<td>{0}</td>
<td>{1}</td>
<td>{2}</td>
<td>{3}</td>
<td>{4}</td>
<td>{5}</td>
<td>{6}</td>
<td>{7}</td>
<td>{8}</td>

<td class='text-right'>
<div class='dropdown'>
	<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
	<ul class='dropdown-menu pull-right'>
		<li><a href='../Product/Product_Add?ed_id={7}' title='Edit'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
		<li><a href='../Product/Product_Add?de_id={7}' title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
	</ul>
</div>
</td>
                    
                    
</tr>", i,ProductName,Invoice,BuyQuantity,BuyingPrice,Amount,Unit,InputDate, SupplierName);
                    i++;
                }
                con.Close();
                ShowData.Controls.Add(new LiteralControl(show));
            }            
        }
    }

}