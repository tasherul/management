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

namespace maganement.Barcode
{
    public partial class GenerateBarcode : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(!IsPostBack)
                {
                    showProdut();
                    pnlStockAdd.Visible = false;
                    txtManualBarcode.Visible = false;
                    chkAutomatic.Checked = true;
                }
                if (Request.QueryString["stock"] != null)
                {
                    string C_ID = Request.QueryString["stock"].ToString();
                    pnlTable.Visible = false;
                    pnlStockAdd.Visible = true;
                    //pnlQuantity.Visible = false;
                    //pnlStockAdd.Visible = true;
                    if (chk.int32CheckSecurity("select count(*) from Stock where s_id=" + C_ID, 1))
                    {
                        string StockID = chk.stringCheck("select stock_id from Stock where s_id=" + C_ID);
                        string p_id = chk.stringCheck("select p_id from Stock where s_id=" + C_ID);
                        int BuyQuantity = chk.int32Check("select BuyQuantity from Stock where s_id=" + C_ID);
                        int Sale = saleCount(Convert.ToInt32(C_ID));
                        int SellingPrice = chk.int32Check("select SellingPrice from ProductAdd where p_id=" + p_id);
                        int Avaiable = BuyQuantity - Sale;
                        lblAvaiable.Text = Avaiable.ToString();
                        if (!IsPostBack)
                        {
                            //txtSellingPrice.Text = SellingPrice.ToString();
                            txtAmount.Text = SellingPrice.ToString();
                            //txtUnit.Text = chk.stringCheck("select Unit from Stock where s_id=" + C_ID);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Error: " + chk.Int32SecurityCheckError + "');", true);
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }

        private void showProdut()
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
            if (ddlProduct.SelectedValue != "0")
            {
                ShowAvaiableData(Convert.ToInt32(ddlProduct.SelectedValue.ToString()));
                pnlStockAdd.Visible = false;

            }
        }
        public int saleCount(int s_id)
        {
            using (SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cons;
                cmd.CommandText = "select * from SaleProductList where s_id=" + s_id;
                cons.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count += Convert.ToInt32(dr["Quantity"].ToString());
                }
                cons.Close();
                if (chk.int32Check("select count(*) from ReturnProduct where s_id=" + s_id) > 0)
                {
                    count += chk.int32Check("select sum(RetuenIteam) from ReturnProduct where s_id=" + s_id);
                }
                return count;
            }
        }
        private void ShowAvaiableData(int p_id)
        {
            //pnlStockAdd.Visible = false;
            pnlTable.Visible = true;
            int sale = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT 
               SellingPrice
              ,ProductAdd.Unit
              ,Stock.stock_id
              ,Stock.s_id
	          ,Stock.BuyQuantity
              ,StockList.Activity
              FROM ProductAdd,Stock,StockList
              where ProductAdd.p_id=Stock.p_id and Stock.stock_id=StockList.stock_id
          and StockList.Activity='True' and ProductAdd.p_id=" + p_id;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string show = "";
            //string query = Request.QueryString[""].ToString();
            while (dr.Read())
            {
                string SellingPrice = dr["SellingPrice"].ToString();
                string Unit = dr["Unit"].ToString();
                string stock_id = dr["stock_id"].ToString();
                string s_id = dr["s_id"].ToString();
                float BuyQuantity = Convert.ToInt32(dr["BuyQuantity"].ToString());
                sale = saleCount(Convert.ToInt32(s_id));
                double Avaiable = (BuyQuantity - sale);
                float SignalPersentage = ((100 / BuyQuantity));
                float SalePersentage = (SignalPersentage * sale);
                string Perentage = SalePersentage.ToString("0.00");
                if (Avaiable > 0)
                {
                    show += string.Format(@"<tr>
											<td>
												<h2>#{0}  <small>Unit: <a class='black bold'>{1}</a></small></h2>
												<small class='block text-ellipsis black'>
													<span class='text-xs Green bold'>{2}</span> <span class='text-muted'>Avaiable, </span>
													<span class='text-xs Red bold'>{3}</span> <span class='text-muted'>Selling Price</span>
												</small>
											</td>
											<td>
                                                <p class='m-b-5'>Sale + Return<span class='text-success pull-right'>{4}</span></p>
                                                <div class='progress progress-xs m-b-0'>
                                                    <div class='progress-bar progress-bar-success' role='progressbar' data-toggle='tooltip' title='{7}' style='width:{5}%'></div>
                                                </div>
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='../Barcode/GenerateBarcode?stock={6}' class='btn btn-xs btn-success'>Choose</a>															
												</div>
											</td>
										</tr>", stock_id, Unit, Avaiable, SellingPrice, sale, Perentage, s_id, SignalPersentage + "-" + SalePersentage);
                }
            }
            con.Close();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(new LiteralControl(show));

        }

        protected void chkAutomatic_CheckedChanged(object sender, EventArgs e)
        {

            if (chkAutomatic.Checked)
            {
                txtManualBarcode.Visible = false;
                txtQuantity.Enabled = true;
            }
            else
            {
                txtManualBarcode.Visible = true;
                txtQuantity.Enabled = false;
            }


        }

        private static List<BarcodeStore> MakeBarcode = new List<BarcodeStore>();

        public class BarcodeStore
        {
            public string ProductName;
            public int ProductCode;
            public string Barcode;
            public double Amount;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}