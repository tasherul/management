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

namespace management.Sale
{
    public partial class ProductSale : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        private static List<StockDetails> StockAdd = new List<StockDetails>();
        management.settings settings = new settings();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(!IsPostBack)
                {
                    showCustomar();
                    showProduct();
                    txtDate.Text = DateTime.Now.ToShortDateString();
             
                    if (!settings.Get_BoolValue_Settings(41))
                        txtSellingPrice.Enabled = false;
                    if (!settings.Get_BoolValue_Settings(42))
                    {
                        txtQuantity.Enabled = false;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Sum()", true);
                    }

                    if (chk.stringCheck("select Barcode_Sell_Enable from m_login where userid='" + Session["m_UserID"].ToString() + "' ").ToLower() == "true" ? true : false)
                    {
                        ddlProductlist.Visible = false;
                        txtBarcode.Visible = true;
                        txtQuantity.Enabled = false;
                    }
                    else
                    {
                        ddlProductlist.Visible = true;
                        txtBarcode.Visible = false;
                        txtQuantity.Enabled = true;
                    }

                }
                //txtMemo.Text = StockAdd.Count.ToString();
                showSellingProduct();
                if (Request.QueryString[""]!=null)
                {
                    string Name = Request.QueryString[""].ToString();
                    pnlTable.Visible = true;
                    pnlStockAdd.Visible = false;
                    if(Name== "Wholesale")
                    {
                        ddlCustomerName.Visible = true;
                        txtAddress.Enabled = false;
                        txtMobile.Enabled = false;
                        txtCustomerName.Visible = false;                        
                        
                    }
                    else
                    {
                        ddlCustomerName.Visible = false;
                        txtCustomerName.Visible = true;
                        txtAddress.Enabled = true;
                        txtMobile.Enabled = true;
                    }
                }
                else
                {
                    Response.Redirect("../Default");
                }
                
                if (Request.QueryString["de"] != null)
                {
                    string ID = Request.QueryString["de"].ToString();
                    Delete(Convert.ToInt32(ID));
                }
                if (Request.QueryString["stock"]!=null)
                {
                    string C_ID = Request.QueryString["stock"].ToString();
                    pnlTable.Visible = false;
                    pnlStockAdd.Visible = true;
                    if (chk.int32CheckSecurity("select count(*) from Stock where s_id=" + C_ID, 1))
                    {
                        string StockID = chk.stringCheck("select stock_id from Stock where s_id=" + C_ID);
                        string p_id = chk.stringCheck("select p_id from Stock where s_id=" + C_ID);
                        int BuyQuantity = chk.int32Check("select BuyQuantity from Stock where s_id=" + C_ID);
                        int Sale = saleCount(Convert.ToInt32(C_ID));
                        int SellingPrice = chk.int32Check("select SellingPrice from ProductAdd where p_id="+p_id);
                        int Avaiable = BuyQuantity - Sale;
                        lblAvaiable.Text = Avaiable.ToString();                        
                        if (!IsPostBack)
                        {
                            txtSellingPrice.Text = SellingPrice.ToString();
                            txtUnit.Text = chk.stringCheck("select Unit from Stock where s_id=" + C_ID);                            
                        }

                        if (Request.QueryString["price"] != null)
                        {
                            bool a = settings.Get_BoolValue_Settings(41);
                            bool b = settings.Get_BoolValue_Settings(42);
                            if (!IsPostBack)
                            {
                                txtAmount.Text = Request.QueryString["price"].ToString();
                                txtSellingPrice.Text = Request.QueryString["price"].ToString();
                                txtQuantity.Text = "1";
                            }
                            if (!a && !b)
                            {
                                ProductADD();
                                Response.Redirect("../Sale/ProductSale?=" + Request.QueryString[""].ToString());
                            }
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Stock Not Found Error (101) " + chk.Int32SecurityCheckError + "');", true);
                    }
                }


            }
            else
            {
                if (Session["m_UserID"] != null)
                    Response.Redirect("~/AuthorizationFailed");
                else
                    Response.Redirect("~/Login?=/Sale/ProductSale?=Retailer");
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
                if (chk.int32Check("select count(*) from ReturnProduct where s_id=" + s_id)>0)
                {
                    count += chk.int32Check("select sum(RetuenIteam) from ReturnProduct where s_id=" + s_id);
                }
                return count;
            }
        }
        private void Delete(int id)
        {
            string q = Request.QueryString[""].ToString();
            StockAdd.RemoveAt(id - 1);
            showSellingProduct();            
            Response.Redirect("../Sale/ProductSale?="+q);
        }

        private void showProduct()
        {
            ddlProductlist.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name,p_id from ProductAdd";
            con.Open();
            ddlProductlist.Items.Add(new ListItem("Select Product", "0"));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["p_id"].ToString();
                ddlProductlist.Items.Add(li);
            }
            con.Close();
        }
        private void showCustomar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Customer";
            ddlCustomerName.Items.Clear();
            ddlCustomerName.Items.Add(new ListItem("Select Customer", "0"));
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["c_id"].ToString();
                ddlCustomerName.Items.Add(li);
            }
            con.Close();

        }
        Check chk = new Check();
        protected void ddlCustomerName_TextChanged(object sender, EventArgs e)
        {
            if(ddlCustomerName.SelectedValue!="0")
            {
                txtAddress.Text = chk.stringCheck("select Address from Customer where c_id="+ddlCustomerName.SelectedValue.ToString());
                txtMobile.Text = chk.stringCheck("select Mobile from Customer where c_id=" + ddlCustomerName.SelectedValue.ToString());
                int PreviousDue = 0;
                txtDue.Text = PreviousDue.ToString();
                pnlTable.Visible = false;
                pnlStockAdd.Visible = false;
            }
            else
            {
                txtMobile.Text = "";
                txtAddress.Text = "";
            }
        }

        protected void ddlProductlist_TextChanged(object sender, EventArgs e)
        {
            if(ddlProductlist.SelectedValue!="0")
            {
                ShowAvaiableData(Convert.ToInt32(ddlProductlist.SelectedValue.ToString()));
            }
        }

        private void ShowAvaiableData(int p_id)
        {
            pnlStockAdd.Visible = false;
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
            string query = Request.QueryString[""].ToString();
            while(dr.Read())
            {
                string SellingPrice = dr["SellingPrice"].ToString();
                string Unit = dr["Unit"].ToString();
                string stock_id = dr["stock_id"].ToString();
                string s_id = dr["s_id"].ToString();
                float BuyQuantity = Convert.ToInt32( dr["BuyQuantity"].ToString());
                sale = saleCount(Convert.ToInt32(s_id));
                double Avaiable = (BuyQuantity - sale);
                float SignalPersentage = ((100 / BuyQuantity));
                float SalePersentage = (SignalPersentage * sale);
                string Perentage =  SalePersentage.ToString("0.00");
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
                                                    <div class='progress-bar progress-bar-success' role='progressbar' data-toggle='tooltip' title='{8}' style='width:{5}%'></div>
                                                </div>
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='../Sale/ProductSale?={6}&stock={7}' class='btn btn-xs btn-success'>Choose</a>															
												</div>
											</td>
										</tr>", stock_id, Unit, Avaiable, SellingPrice, sale, Perentage, query, s_id, SignalPersentage + "-" + SalePersentage);
                }
            }
            con.Close();
            pnlShow.Controls.Clear();
            pnlShow.Controls.Add(new LiteralControl(show));

        }

        public class StockDetails
        {            
            public string ProductName;
            public string ProductCode;
            public string Stock_id;
            public int s_id;
            public int Quantity;
            public string Unit;
            public double SellingPrice;
            public double Amount;
            public string Barcode;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ProductADD();
        }
        private void ProductADD()
        {
            if (txtAmount.Text != "" || txtAmount.Text != "Null" || txtAmount.Text != "0" || txtAmount.Text != "NaN")
            {
                string s_ids = Request.QueryString["stock"].ToString();
                string Stock_id = chk.stringCheck("select stock_id from Stock where s_id=" + s_ids);
                string ProductName = chk.stringCheck("select ProductName from Stock where s_id=" + s_ids);
                string ProductCode = chk.stringCheck("select p_id from Stock where s_id=" + s_ids);
                int BuyQuantity = chk.int32Check("select BuyQuantity from Stock where s_id=" + s_ids);
                int Sale = saleCount(Convert.ToInt32(s_ids));
                int Avaiable = BuyQuantity - Sale;
                int Total_Stock_S_id = 0;
                foreach (StockDetails Stock in StockAdd)
                {
                    if (Stock.s_id == Convert.ToInt32(s_ids))
                    {
                        Total_Stock_S_id += Stock.Quantity;//0---15
                    }
                }
                bool ON = true;
                if(settings.Get_BoolValue_Settings(43))
                {
                    int BuyingPrice = chk.int32Check("select BuyingPrice from Stock where s_id=" + s_ids);
                    int sellPrice = Convert.ToInt32(txtSellingPrice.Text);
                    if(sellPrice< BuyingPrice)//300>680
                    {
                        ON = false;
                    }
                    else
                    {
                        ON = true;
                    }
                }

                if (Avaiable >= Total_Stock_S_id)//20>=0---20>=15
                {//15---12
                    int countAvaiable = Avaiable - Total_Stock_S_id;
                    if (countAvaiable >= Convert.ToInt32(txtQuantity.Text))
                    {
                        if (ON)
                        {
                            StockAdd.Add(new StockDetails()
                            {
                                ProductName = ProductName,
                                ProductCode = ProductCode,
                                Stock_id = Stock_id,
                                s_id = Convert.ToInt32(s_ids),
                                Quantity = Convert.ToInt32(txtQuantity.Text),
                                Unit = txtUnit.Text,
                                SellingPrice = Convert.ToInt32(txtSellingPrice.Text),
                                Amount = Convert.ToInt32(txtAmount.Text),
                                Barcode = Request.QueryString["bc"] != null ? Request.QueryString["bc"].ToString() : ""
                            });
                            pnlStockAdd.Visible = false;
                            showSellingProduct();
                            
                            // Response.Redirect("../Sale/ProductSale?=" + Request.QueryString[""].ToString());

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : This Price You Can not Sale. Type Your Selling Price.');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Already insert All Product.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Already insert All Product.');", true);
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Input the Quality and Set Selling Price.');", true);
            }
        }
        private void showSellingProduct()
        {
            string Show = "";
            pnlShowData.Controls.Clear();
            int i = 1;
            int totalStock = 0;
            double totalAmount = 0;
            string Sale = Request.QueryString[""].ToString();
            foreach (StockDetails Stock in StockAdd)
            {
                string bCode = Stock.Barcode != "" ? "<br><b><sub>" + Stock.Barcode + "</sub></b>" : "";
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
                                                <li><a href='../Sale/ProductSale?={6}&de={0}'><i class='fa fa-dot-circle-o text-danger'></i>Delete</a></li>
                                              </ul>
                                        </div>
                                    </td>                                    
                                </tr>", i, Stock.ProductName+ bCode, Stock.Quantity, Stock.Unit, Stock.SellingPrice, Stock.Amount, Sale);
                i++;
                totalStock += Stock.Quantity;
                totalAmount += Stock.Amount;
            }
            txtSubtotal.Text = totalAmount.ToString();
            lblQuality.Text = totalStock.ToString();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "TotalSum()", true);
            pnlShowData.Controls.Add(new LiteralControl(Show));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string Invoice = "";
            string Type = Request.QueryString[""].ToString();
            if (StockAdd.Count>0)
            {
                if (Type == "Wholesale" && ddlCustomerName.SelectedValue == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Wholesale must select the customer name.');", true);
                }
                else
                {
                    string Error2 = "";
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = @"insert into SaleList (Invoice_no
                      ,Memo
                      ,CustomerName
                      ,c_id
                      ,CustomerAddress
                      ,CustomerMobile
                      ,saleType
                      ,TotalProduct
                      ,TotalQuantity
                      ,SubTotal
                      ,Payment
                      ,Discount
                      ,DiscountType
                      ,DiscountAmount
                      ,Vat
                      ,VatType
                      ,VatAmount
                      ,PreviousDue
                      ,TotalDue
                      ,DueDate
                      ,InWord
                      ,Remark
                      ,SubmitDate
                      ,InputDateTime
                      ,InputDate
                      ,userid) values
                      (@Invoice_no
                      ,@Memo
                      ,@CustomerName
                      ,@c_id
                      ,@CustomerAddress
                      ,@CustomerMobile
                      ,@saleType
                      ,@TotalProduct
                      ,@TotalQuantity
                      ,@SubTotal
                      ,@Payment
                      ,@Discount
                      ,@DiscountType
                      ,@DiscountAmount
                      ,@Vat
                      ,@VatType
                      ,@VatAmount
                      ,@PreviousDue
                      ,@TotalDue
                      ,@DueDate
                      ,@InWord
                      ,@Remark
                      ,@SubmitDate
                      ,@InputDateTime
                      ,@InputDate
                      ,@userid)";
                        RandomNumber RN = new RandomNumber();
                        RN.Number = true;
                        RN.HowMuchNumber = chk.int32Check("select ValueInt from Settings where id=2");
                        Invoice = RN.RandomStringNumber("InvoiceID");
                        string CustomerName = ""; string CustomarCode = "";

                        int TotalProduct = 0; int TotalQuantity = 0;
                        double SubTotal = Convert.ToDouble(txtSubtotal.Text);
                        double Discount = Convert.ToDouble(txtDiscount.Text);
                        double Vat = Convert.ToDouble(txtVat.Text);
                        double DiscountAmount = 0;
                        double VatAmount = 0;
                        double Payment = Convert.ToDouble(txtPayment.Text);
                        double TotalDue = Convert.ToDouble(txtTotal.Text);
                        double PrebiousDue = Convert.ToDouble(txtDue.Text);
                        if (Type == "Wholesale")
                        {
                            CustomerName = ddlCustomerName.SelectedItem.ToString();
                            CustomarCode = ddlCustomerName.SelectedValue.ToString();
                        }
                        else
                        {
                            CustomerName = txtCustomerName.Text;
                        }
                        foreach (StockDetails Stock in StockAdd)
                        {
                            TotalProduct++;
                            TotalQuantity = Stock.Quantity;
                        }
                        if (ddlDiscount.SelectedItem.ToString() == "%")
                        {
                            DiscountAmount = (SubTotal * Discount) / 100;
                        }
                        else
                        {
                            DiscountAmount = Discount;
                        }
                        if (ddlVat.SelectedItem.ToString() == "%")
                        {
                            VatAmount = (SubTotal * Vat) / 100;
                        }
                        else
                        {
                            VatAmount = Vat;
                        }

                        cmd.Parameters.AddWithValue("@Invoice_no", Invoice);
                        cmd.Parameters.AddWithValue("@Memo", txtMemo.Text);
                        cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                        cmd.Parameters.AddWithValue("@c_id", CustomarCode);
                        cmd.Parameters.AddWithValue("@CustomerAddress", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@CustomerMobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@saleType", Type);
                        cmd.Parameters.AddWithValue("@TotalProduct", TotalProduct);
                        cmd.Parameters.AddWithValue("@TotalQuantity", TotalQuantity);
                        cmd.Parameters.AddWithValue("@SubTotal", SubTotal);
                        cmd.Parameters.AddWithValue("@Payment", Payment);
                        cmd.Parameters.AddWithValue("@Discount", Discount);
                        cmd.Parameters.AddWithValue("@DiscountType", ddlDiscount.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@DiscountAmount", DiscountAmount);
                        cmd.Parameters.AddWithValue("@Vat", Vat);
                        cmd.Parameters.AddWithValue("@VatType", ddlVat.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@VatAmount", VatAmount);
                        cmd.Parameters.AddWithValue("@PreviousDue", PrebiousDue);
                        cmd.Parameters.AddWithValue("@TotalDue", TotalDue);
                        cmd.Parameters.AddWithValue("@DueDate", "");
                        cmd.Parameters.AddWithValue("@InWord", txtInWord.Text);
                        cmd.Parameters.AddWithValue("@Remark", txtRemark.Text);
                        cmd.Parameters.AddWithValue("@SubmitDate", txtDate.Text);
                        cmd.Parameters.AddWithValue("@InputDateTime", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@InputDate", DateTime.Now.ToString("dd MMMM yyyy"));
                        cmd.Parameters.AddWithValue("@userid", Session["m_UserID"].ToString());
                        con.Open();
                        cmd.ExecuteNonQuery().ToString();
                        con.Close();
                        //int s_id = chk.int32Check("");
                        int sale_id = chk.int32Check("select sale_id from SaleList where Invoice_no='" + Invoice + "'");
                                          
                        foreach (StockDetails stock in StockAdd)
                        {                            
                            chk.boolCheck(string.Format(@"insert into SaleProductList (sale_id,p_id,ProductName,Quantity,Unit,SellingPrice,Amount,Invoice_no,s_id,stock_id) values({0},{1},'{2}',{3},'{4}',{5},{6},'{7}',{8},{9})", sale_id, Convert.ToInt32(stock.ProductCode), stock.ProductName, stock.Quantity, stock.Unit, stock.SellingPrice, stock.Amount, Invoice,stock.s_id,Convert.ToInt32(stock.Stock_id) ));
                            if(stock.Barcode!="")
                            {
                                chk.boolCheck("update Barcode set Sell_Code='true' where BarCode='"+stock.Barcode+"' ");
                            }
                            //InsertDataStockProductlist(sale_id,stock.s_id,Invoice,Convert.ToInt32(stock.ProductCode),stock.ProductName,stock.Quantity,stock.Unit,stock.SellingPrice,stock.Amount);
                            //int CountTotalQuantity = chk.int32Check("select BuyQuantity from Stock where s_id=" + stock.s_id);
                            //int CountSaleQuantity = saleCount(stock.s_id);
                            //int AddQuantity = stock.Quantity;
                            //int Avaiable = CountTotalQuantity - CountSaleQuantity;
                            //if (Avaiable == AddQuantity)
                            //{
                            //    soldThisProduct(stock.s_id);
                            //}
                        }
                        StockAdd.Clear();
                        Response.Redirect("~/invoice/?=" + Invoice);

                        }
                        catch (Exception er)
                        {

                            lblResult.Text = "Error: "+er.Message;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Error1:" + er + "');", true);
                        }
                      

            }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Please Insert a Product to sale.');", true);
            }
        }

        //private void soldThisProduct(int s_id)
        //{
        //    //string Stockid = chk.StringSecurityCheck(");
        //    //chk.StringSecurityCheck("update StockList set Activity='Sold' where stock_id="+Stockid);
        //    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandText = "select stock_id from Stock where s_id = "+s_id.ToString();
        //        cn.Open();
        //        string Stockid = cmd.ExecuteScalar().ToString();
        //        cn.Close();
        //        cmd.CommandText = "update StockList set Activity='Sold' where stock_id=" + Stockid;
        //        cn.Open();
        //        cmd.ExecuteNonQuery().ToString();
        //        cn.Close();
        //    }
                
        //}

        private void InsertDataStockProductlist(int sale_id, int s_id, string Invoice, int ProductCode, string ProductName, int Quantity,string Units,double SellingPrice,double Amount)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"insert into SaleProductList (sale_id,s_id,Invoice_no,p_id,ProductName,Quantity,Unit,SellingPrice,Amount) values(@sale_id,@s_id,@Invoice_no,@p_id,@ProductName,@Quantity,@Unit,@SellingPrice,@Amount)";
            cmd.Parameters.AddWithValue("@sale_id", sale_id);
            cmd.Parameters.AddWithValue("@s_id", s_id);
            cmd.Parameters.AddWithValue("@Invoice_no", Invoice);
            cmd.Parameters.AddWithValue("@p_id", ProductCode);
            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Unit", Units);
            cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if(chk.int32CheckSecurity("select count(*) from Barcode where BarCode='"+txtBarcode.Text+ "' and Sell_Code  != 'true'", 1))
            {
                bool find = false;
                foreach(StockDetails s in StockAdd)
                {
                    if (s.Barcode == txtBarcode.Text)
                        find = true; 
                }
                if (find)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Product is insert once');", true);
                    txtBarcode.Text = "";
                    pnlStockAdd.Visible = false;
                }
                else
                {
                    string s_id = chk.stringCheck("select s_id from Barcode where BarCode='" + txtBarcode.Text + "' ");
                    //string p_id = chk.stringCheck("select p_id from Barcode where BarCode='" + txtBarcode.Text + "' ");
                    string Price = chk.stringCheck("select Product_Price from Barcode where BarCode='" + txtBarcode.Text + "' ");

                    Response.Redirect("../Sale/ProductSale?=" + Request.QueryString[""].ToString() + "&stock=" + s_id + "&price=" + Price + "&bc=" + txtBarcode.Text);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Message : Product is not found or sell it. Try another code.');", true);
                txtBarcode.Text = "";
            }
        }

        protected void chkBarcode_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}