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
        Check chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            //session check and Verify the page authrity
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                {
                    showProduct();//show the product in dorpdownlist
                }
                pnlReturnIteams.Visible = false;
                pnlSaleIteams.Visible = false;
                pnlShowRetuen.Visible = false;
                pnlPreviousReturn.Visible = false;
                pnlRemark.Visible = false;
                if (Request.QueryString["sc_id"]!=null && Request.QueryString["s_id"]!=null)
                {
                    pnlReturnIteams.Visible = true;
                    pnlSaleIteams.Visible = true;
                    pnlShowRetuen.Visible = true;
                    pnlPreviousReturn.Visible = true;
                    pnlRemark.Visible = true;
                    string sc_id = Request.QueryString["s_id"].ToString();
                    string s_id = Request.QueryString["sc_id"].ToString();
                    var st = " from Stock where s_id="+s_id;
                    int Sale = 0;
                    if (chk.int32Check("select count(*) from SaleProductList where s_id="+s_id)>0)
                    {
                        Sale = chk.int32Check("select sum(Quantity) from SaleProductList where s_id=" + s_id);
                    }
                    
                    int totalIteams = chk.int32Check("select BuyQuantity " + st);
                    int Avaiable = totalIteams - Sale;
                    // int BuyingPrice = chk.int32Check("select BuyingPrice " + st);
                    int PreviousReturn = 0;
                    if (!IsPostBack)
                    {
                        
                        
                        if(chk.int32Check("select count(*) from ReturnProduct where s_id=" +Convert.ToInt32(s_id)+" ")>0)
                        {
                            PreviousReturn= chk.int32Check("select sum(RetuenIteam) from ReturnProduct where s_id=" + s_id);
                        }
                        Avaiable = (Avaiable - PreviousReturn);
                        txtPreviousReturn.Text = PreviousReturn.ToString();
                        txtBuyingPrice.Text = chk.stringCheck("select BuyingPrice " + st);
                        txtAmount.Text = "0";// chk.stringCheck("select BuyingPrice " + st);
                        txtAvaiableStock.Text = Avaiable.ToString();
                        txtSaleIteams.Text = Sale.ToString();
                        //txtTtotalAmount.Text = chk.stringCheck("select Amount " + st);
                        txtUnit.Text = chk.stringCheck("select Unit " + st);
                    }
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
                pnlReturnIteams.Visible = false;
                pnlSaleIteams.Visible = false;
                pnlShowRetuen.Visible = false;
                pnlPreviousReturn.Visible = false;
                pnlRemark.Visible = false;
                string c_id = ddlProduct.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT
	s.s_id,s.stock_id, s.ProductName,BuyQuantity,BuyingPrice,Amount,Unit,l.InputDate,l.Invoice,l.Activity,
	case
	when l.c_id=(select c_id from Supplier where l.c_id=c_id) then 
	(select name from Supplier where l.c_id=c_id)
	else 'NULL'
	end as SupplierName
  FROM Stock as s,StockList as l where s.stock_id=l.stock_id
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
                    string Activity = dr["Activity"].ToString();
                    string Author = "";string return_p = "";
                    if (Activity == "True")
                    {
                        Author = "<i class='fa fa-dot-circle-o text-success'></i> Active";
                        return_p = "<ul class='dropdown-menu pull-right'><li><a href='../Return/Purchase_Add?sc_id=" + s_id+"&s_id="+stock_id+ "' title='Edit'><i class='fa fa-pencil m-r-5'></i> Return</a></li><li><a href='../Barcode/GenerateBarcode?productid="+ s_id + "' title='Barcode'><i class='fa fa-barcode m-r-5'></i> Barcode</a></li></ul>";

                    }
                    else if (Activity == "False")
                    {
                        Author = "<i class='fa fa-dot-circle-o text-danger'></i> Deactive";
                        return_p = "<ul class='dropdown-menu pull-right'><li><a href='../Return/Purchase_Add?sc_id=" + s_id + "&s_id=" + stock_id + "' title='Edit'><i class='fa fa-pencil m-r-5'></i> Return</a></li><li><a href='../Barcode/GenerateBarcode?productid=" + s_id + "' title='Barcode'><i class='fa fa-barcode m-r-5'></i> Barcode</a></li></ul>";
                    }
                    else
                    {
                        Author = "<i class='fa fa-times text-danger'></i> Sold";
                        return_p = "<ul class='dropdown-menu pull-right'><li><a href='../Return/Purchase_Add?sc_id=" + s_id + "&s_id=" + stock_id + "' title='Edit'><i class='fa fa-pencil m-r-5'></i> Return</a></li><li><a href='../Barcode/GenerateBarcode?productid=" + s_id + "' title='Barcode'><i class='fa fa-barcode m-r-5'></i> Barcode</a></li></ul>";
                    }
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
<td>{9}</td>
<td class='text-right'>
<div class='dropdown'>
	<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
		{10}
</div>
</td>
                    
                    
</tr>", i,ProductName,Invoice,BuyQuantity,BuyingPrice,Amount,Unit,InputDate, SupplierName,Author, return_p);
                    i++;
                }
                con.Close();
                ShowData.Controls.Add(new LiteralControl(show));
            }            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (txtReturnIteams.Text != "" && txtBuyingPrice.Text != "" & txtAmount.Text != "")
            {
                string sc_id = Request.QueryString["s_id"].ToString();//sotck id
                string s_id = Request.QueryString["sc_id"].ToString();//sub stock id
                string c_id = chk.stringCheck("select c_id from StockList where stock_id='"+ sc_id + "'");
                string p_id = chk.stringCheck("select p_id from Stock where s_id="+s_id);
                string ProductName = chk.stringCheck("select ProductName from Stock where s_id=" + s_id);
                //chk.boolCheck(string.Format(@"insert into ReturnProduct (p_id,ProductName,sc_id,s_id,c_id,ReturnPrice,RetuenIteam,Amount,InputDate,InputDateTime) values(" + Convert.ToInt32(p_id) + ",'" + ProductName + "'," + Convert.ToInt32(sc_id) + "," + Convert.ToInt32(s_id) +"," + Convert.ToInt32(c_id) + "," + Convert.ToInt32(txtBuyingPrice.Text) + "," + (txtReturnIteams.Text) + "," + Convert.ToInt32(txtAmount.Text) + ",'" + DateTime.Now.ToString("dd MMMM yyyy") + "','" + DateTime.Now.ToString() + "')"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into ReturnProduct (p_id,ProductName,sc_id,s_id,c_id,ReturnPrice,RetuenIteam,Amount,InputDate,InputDateTime,userid,Remark) values(@p_id,@ProductName,@sc_id,@s_id,@c_id,@ReturnPrice,@RetuenIteam,@Amount,@InputDate,@InputDateTime,@userid,@Remark)";
                cmd.Parameters.AddWithValue("@p_id", p_id);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@sc_id", sc_id);
                cmd.Parameters.AddWithValue("@s_id", s_id);
                cmd.Parameters.AddWithValue("@c_id", c_id);
                cmd.Parameters.AddWithValue("@ReturnPrice", txtBuyingPrice.Text);
                cmd.Parameters.AddWithValue("@RetuenIteam", txtReturnIteams.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@InputDate", DateTime.Now.ToString("dd MMMM yyyy"));
                cmd.Parameters.AddWithValue("@InputDateTime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@userid",Session["m_UserID"].ToString());
                cmd.Parameters.AddWithValue("@Remark",txtRemark.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                //{
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege: You have a Return Product.');", true);
                 Response.Redirect("../Return/Purchase_Add");
                //}
                //else
                //{
                //    string messege = chk.BoolSecurityErrorMessege;
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege:"+ messege + "');", true);
                //}
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Messege: Requid Quantity, Return & Anount');", true);
            }
        }
    }

}