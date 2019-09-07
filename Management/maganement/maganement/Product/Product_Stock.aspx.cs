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


namespace maganement.Product
{
    public partial class Product_Stock : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        public static List<StockDetails> StockAdd = new List<StockDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(!IsPostBack)
                {
                    showProduct();
                    showSupplier();
                    txtBuyQuantity.Enabled = false;
                    btnStockAdd.Enabled = false;
                    txtAmount.Enabled = false;
                    txtBuyingPrice.Enabled = false;
                }
                //txtBuyQuantity.Attributes.Add("onkeyup", "Sum();");
                if(Request.QueryString["de"]!=null)
                {
                    string ID = Request.QueryString["de"].ToString();
                    Delete(Convert.ToInt32(ID));
                }
                ShowDatainList();

            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }

        }

        private void showSupplier()
        {
            ddlSuppliers.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name,c_id from Supplier";
            con.Open();
            ddlSuppliers.Items.Add(new ListItem("Select Supplier", "0"));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["c_id"].ToString();
                ddlSuppliers.Items.Add(li);
            }
            con.Close();
        }

        Check chk = new Check();
        private void showProduct()
        {
            ddlProduct.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name,p_id from ProductAdd";
            con.Open();
            ddlProduct.Items.Add(new ListItem("Select Product", "0"));
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["p_id"].ToString();
                ddlProduct.Items.Add(li);
            }
            con.Close();
        }

        private void show()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name from ProductAdd";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string Shows = "";
            int i = 1;
            int all = chk.int32Check("select count(*) from ProductAdd");
            while(dr.Read())
            {
                Shows += "'"+dr["Name"].ToString().Replace(" ","")+"'";
                if(i!=all)
                {
                    Shows += ",";
                }
                i++;
            }
            con.Close();

            ClientScript.RegisterStartupScript(GetType(), "", @"$(function() {var availableTags = [	"+Shows+ "	];	$('#xxxxxx').autocomplete({	source: availableTags	});	});", true);
        }

        protected void ddlProduct_TextChanged(object sender, EventArgs e)
        {
            if(ddlProduct.SelectedValue!="0")
            {
                string ID = ddlProduct.SelectedValue.ToString();
                string BuingPrice = chk.stringCheck("select BuingPrice from ProductAdd where p_id="+ID);
                string Unit = chk.stringCheck("select Unit from ProductAdd where p_id=" + ID);
                txtUnit.Text = Unit;
                txtBuyingPrice.Text = BuingPrice;
                txtBuyQuantity.Text = "";
                txtBuyQuantity.Enabled = true;
                btnStockAdd.Enabled = true;
                txtBuyingPrice.Enabled = true;
                txtAmount.Enabled = true;
            }
            else
            {
                txtBuyQuantity.Enabled = false;
                btnStockAdd.Enabled = false;
                txtBuyingPrice.Enabled = false;
                txtAmount.Enabled = false;
            }
        }

        public class StockDetails
        {
            public int ID;
            public string ProductName;
            public string ProductCode;
            public int Quantity;
            public string Unit;
            public double BuyingPrice;
            public double Amount;
        }
        //public static int length = StockAdd.Count;
        protected void btnStockAdd_Click(object sender, EventArgs e)
        {
            if(txtBuyQuantity.Text!="")
            {
                int length = StockAdd.Count;
                //for(int i=0;i<length+1;i++)
                //{
                //_CreateStock[i].ID = i;
                //_CreateStock[i].ProductName = ddlProduct.SelectedItem.ToString();
                //_CreateStock[i].ProductCode = ddlProduct.SelectedValue.ToString();
                //_CreateStock[i].Quantity = Convert.ToInt32(txtBuyQuantity.Text);
                //_CreateStock[i].BuyingPrice = Convert.ToInt32(txtBuyingPrice.Text);
                //_CreateStock[i].Amount = Convert.ToInt32(txtAmount.Text);
                StockAdd.Add(new StockDetails() {
                    ID = length,
                    ProductName = ddlProduct.SelectedItem.ToString(),
                    ProductCode = ddlProduct.SelectedValue.ToString(),
                    Quantity = Convert.ToInt32(txtBuyQuantity.Text),
                    BuyingPrice = Convert.ToDouble(txtBuyingPrice.Text),
                    Amount = Convert.ToDouble(txtAmount.Text),
                    Unit = txtUnit.Text
                });
                //}
                ddlProduct.SelectedValue = "0";
                txtBuyQuantity.Text = "";
                txtBuyQuantity.Enabled = false;
                txtAmount.Text = "0";
                txtBuyingPrice.Text = "0";
                txtUnit.Text = "Null";
                txtBuyingPrice.Enabled = false;
                txtAmount.Enabled = false;
                ShowDatainList();

            }

        }
        public void ShowDatainList()
        {
            string Show = "";
            ShowData.Controls.Clear();
            int i = 1;
            int totalStock = 0;
            double totalAmount = 0;
            foreach (StockDetails Stock in StockAdd)
            {
                Show += string.Format(@"<tr>
                                    <td>
                                        <a class='circle m-r-10 dColor'>{0}</a>
                                        <h2>{1}</h2>
                                    </td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>
                                        <div class='dropdown action-label'>
                                            <a class='btn btn-white btn-sm rounded dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-dot-circle-o text-success'></i>Active <i class='caret'></i></a>
                                            <ul class='dropdown-menu'>
                                                <li><a href='#'><i class='fa fa-dot-circle-o text-success'></i>Active</a></li>
                                                <li><a href='../Product/Product_Stock?de={0}'><i class='fa fa-dot-circle-o text-danger'></i>Delete</a></li>
                                              </ul>
                                        </div>
                                    </td>                                    
                                </tr>",i, Stock.ProductName, Stock.Quantity, Stock.Unit, Stock.BuyingPrice, Stock.Amount);
                i++;
                totalStock += Stock.Quantity;
                totalAmount += Stock.Amount;
            }
            ShowData.Controls.Add(new LiteralControl(Show));
            txtTotalStock.Text = totalStock.ToString();
            txtTtotalAmount.Text = totalAmount.ToString();
        }
        public void Delete(int id)
        {
            StockAdd.RemoveAt(id-1);
            ShowDatainList();
            Response.Redirect("../Product/Product_Stock");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(StockAdd.Count > 0)
            {
                try
                {
                    RandomNumber RN = new RandomNumber();
                    RN.Number = true;
                    string StockID = RN.RandomStringNumber("StockID");
                    foreach (StockDetails Stock in StockAdd)
                    {
                        chk.stringCheck("insert into Stock (stock_id,p_id,ProductName,BuyQuantity,BuyingPrice,Amount,Unit) values('" + StockID + "'," + Stock.ProductCode + ", '" + Stock.ProductName + "', " + Stock.Quantity + "," + Stock.BuyingPrice + ", " + Stock.Amount + ",'" + Stock.Unit + "' )");
                    }
                    chk.stringCheck(@"insert into StockList (stock_id,c_id,SuppliersName,Invoice,Remark,userid,InputDateTime,InputDate,TotalAmount,TotalStock,Activity) values('" + StockID + "',"+ddlSuppliers.SelectedValue.ToString()+",'"+ddlSuppliers.SelectedItem.ToString()+"','"+txtInvoice.Text+"','"+txtRemark.Text+"','"+Session["m_UserID"] +"','"+DateTime.Now.ToString()+"','"+DateTime.Now.ToString("dd MMMM yyyy") +"',"+txtTtotalAmount.Text+","+txtTotalStock.Text+",'True' )");
                    StockAdd.Clear();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Product in your stock.');", true);
                    ShowDatainList();
                    //Response.Redirect("../Product/Product_Stock");
                }
                catch(Exception err)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : "+err.Message+"');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Please Add a product stock then Click submit.');", true);
            }
        }
      

    }
}