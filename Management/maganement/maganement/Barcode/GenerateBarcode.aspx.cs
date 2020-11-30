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

namespace management.Barcode
{
    public partial class GenerateBarcode : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        private static string S_ID { get; set; }
        private static string P_ID { get; set; }
        private static int Avaiable_Product { get; set; }
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
                    btnBarCodeGenerater.Visible = false;
                    btnClear.Visible = false;
                }
                if(Request.QueryString["p"] != null)
                {
                    lblProductName.Text = "<strong>("+Request.QueryString["p"].ToString()+ ")</strong>";
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
                        showBarCodes();
                        S_ID = C_ID;                        
                        string StockID = chk.stringCheck("select stock_id from Stock where s_id=" + C_ID);
                        string p_id = chk.stringCheck("select p_id from Stock where s_id=" + C_ID);
                        P_ID = p_id;
                        int BuyQuantity = chk.int32Check("select BuyQuantity from Stock where s_id=" + C_ID);
                        int Sale = saleCount(Convert.ToInt32(C_ID));
                        int SellingPrice = chk.int32Check("select SellingPrice from ProductAdd where p_id=" + p_id);
                        int Avaiable = BuyQuantity - Sale;
                        Avaiable_Product = Avaiable;
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
                showBarCodes();
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
              ,ProductAdd.Name
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
													<a href='../Barcode/GenerateBarcode?stock={6}&p={8}' class='btn btn-xs btn-success'>Choose</a>															
												</div>
											</td>
										</tr>", stock_id, Unit, Avaiable, SellingPrice, sale, Perentage, s_id, SignalPersentage + "-" + SalePersentage, dr["Name"].ToString());
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
            public string ID { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public double Amount { get; set; }
            public string s_id { get; set; }
            public string p_id { get; set; }
            public string DateTime { get; set; }
            public bool ManualMode { get; set; }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int Quality = Convert.ToInt32(txtQuantity.Text);
            lblResult.Text = "";
            if (Avaiable_Product>= Quality)
            {
                int TotalCount = chk.int32Check("select count(*) from Barcode where s_id=" + S_ID + " and p_id=" + P_ID);
                RandomNumber ran = new RandomNumber();
                settings set = new settings();
                ran.Number = true;
                ran.HowMuchNumber = set.Get_InValue_Settings(16);
                string GeneratID = ran.RandomStringNumber("Barcode");
                bool auto = false;bool manual = false;
                if ((Avaiable_Product - TotalCount) >= Quality && chkAutomatic.Checked && txtQuantity.Text!="")
                {          
                        for (int i = 0; i < Quality; i++)
                        {
                            string Code = ran.RandomStringNumber("Barcode");
                            MakeBarcode.Add(new BarcodeStore()
                            {
                                ID = GeneratID,
                                Amount = Convert.ToInt32(txtAmount.Text),
                                Barcode = Code,
                                p_id = P_ID,
                                s_id = S_ID,
                                ProductName = Request.QueryString["p"].ToString(),
                                DateTime = DateTime.Now.ToString()
                            });
                        }
                        showBarCodes();
                    auto = true;
                    manual = false;
                }
                else if(!chkAutomatic.Checked && txtManualBarcode.Text!="")
                {
                    string Code = txtManualBarcode.Text;
                    if(chk.int32Check("select count(*) from Barcode where BarCode='"+Code+"' ")==0)
                    { 
                        int limit = Avaiable_Product - TotalCount;int find = 0;
                        bool codeMatch = false;
                        foreach(BarcodeStore b in MakeBarcode)
                        {
                            if(b.p_id ==P_ID && b.s_id == S_ID)
                            {
                                find++;
                            }
                            if (Code == b.Barcode)
                                codeMatch = true;
                        }
                        if (limit > find && codeMatch)
                        {
                            MakeBarcode.Add(new BarcodeStore()
                            {
                                ID = GeneratID,
                                Amount = Convert.ToInt32(txtAmount.Text),
                                Barcode = Code,
                                p_id = P_ID,
                                s_id = S_ID,
                                ProductName = Request.QueryString["p"].ToString(),
                                DateTime = DateTime.Now.ToString(),
                                ManualMode=true
                            });
                            showBarCodes();
                        }
                        else
                        {
                            lblResult.Text = "<div class='alert alert-danger'>You can't add already all iteams are avaiable or Code matched Clear manual code.</div>";
                        }
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'>This Barcode is avaiable other products try another code.</div>";
                    }
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'>Already BarCode is avaiable. You can add "+ (Avaiable_Product -TotalCount) + " Items.</div>";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'>Your Quality is over the Maximam</div>";
            }
        }

        private void showBarCodes()
        {
            string show ="";int i = 1;bool x = false;
            foreach(BarcodeStore s in MakeBarcode)
            {
                x = true;
                show += string.Format(@"<tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                            <td>{2}</td>
                                            <td>{3}</td>
                                        </tr>",i,s.ProductName,s.Barcode,s.Amount);
                i++;
            }
            pnlBarcode.Controls.Clear();
            pnlBarcode.Controls.Add(new LiteralControl(show));
            if(x)
            {
                btnBarCodeGenerater.Visible = true;
                btnClear.Visible = true;
            }
        }

        protected void btnBarCodeGenerater_Click(object sender, EventArgs e)
        {
            string sid = "";
            foreach(BarcodeStore s in MakeBarcode)
            {
                sid = s.ID;
                chk.BoolSecurityCheck(string.Format(@"insert into Barcode (s_id,p_id,BarCode,Product_Name,Product_Price,DateTime,GeneratID,Sell_Code) values({0},{1},'{2}','{3}','{4}','{5}','{6}','false')", s.s_id,s.p_id,s.Barcode,s.ProductName,s.Amount,s.DateTime,s.ID));
            }
            MakeBarcode.Clear();
            Response.Redirect("~/Invoice/Barcode?="+sid);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            MakeBarcode.Clear();
            showBarCodes();
            Response.Redirect("~/Barcode/GenerateBarcode");
        }
    }
}