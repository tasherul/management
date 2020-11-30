using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.CustomerSupplier
{
    public partial class ViewSupplier : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (Request.QueryString[""] != null)
                {
                    string ID = Request.QueryString[""].ToString();
                    if (_Chk.int32Check("select count(*) from Supplier where c_id=" + ID) == 1)
                    {
                        string st = " from Supplier where c_id=" + ID;
                        lblName.Controls.Add(new LiteralControl(_Chk.stringCheck("select Name" + st)));
                        lblCustomerID.Controls.Add(new LiteralControl(ID));
                        lblDetails.Controls.Add(new LiteralControl(_Chk.stringCheck("select Details" + st)));
                        lblEmail.Controls.Add(new LiteralControl(_Chk.stringCheck("select Email" + st)));
                        lblGender.Controls.Add(new LiteralControl(_Chk.stringCheck("select Gender" + st)));
                        lblPhone.Controls.Add(new LiteralControl(_Chk.stringCheck("select Mobile" + st)));
                        lblAddress.Controls.Add(new LiteralControl(_Chk.stringCheck("select Address" + st)));

                        ShowStockList();
                        ShowStock();
                        showReturn();
                    }
                    else
                    {
                        Response.Redirect("Error?=Customer Not Found.");
                    }
                }


            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }


        }
        Check _chk = new Check();

        private void showReturn()
        {
            string ID = Request.QueryString[""].ToString();
            pnlShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ReturnProduct where c_id="+ ID;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int num = 1; string ShowD = "";
            while (dr.Read())
            {
                string ProductName = dr["ProductName"].ToString();
                string sc_id = dr["sc_id"].ToString();
                string s_id = dr["s_id"].ToString();
                string c_id = dr["c_id"].ToString();
                string ReturnPrice = dr["ReturnPrice"].ToString();
                string RetuenIteam = dr["RetuenIteam"].ToString();
                string Amount = dr["Amount"].ToString();
                string InputDate = dr["InputDate"].ToString();
                string p_id = dr["p_id"].ToString();
                string r_id = dr["r_id"].ToString();

                ShowD += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
											<td>{3}</td>
											<td>{4}</td>
											<td>{5}</td>
                                            <td>{6}</td>											
										</tr>", num, ProductName, RetuenIteam, ReturnPrice, Amount, InputDate, _chk.stringCheck("select Unit from ProductAdd where p_id=" + p_id.ToString()));
                num++;
            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(ShowD));


            /* 
             <td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../Invoice/Return?={8}' title='Invoice'><i class='fa fa-pencil m-r-5'></i> Invoice</a></li>
														<li><a href='../Return/Purchase_Add?de_id={8}' title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
             
             */
        }

        private void ShowStock()
        {
            string C_ID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT  s_id
      ,stock.stock_id
      ,ProductName
      ,BuyQuantity
      ,BuyingPrice
      ,Amount
      ,Unit
        FROM Stock,StockList
where StockList.stock_id=Stock.stock_id and StockList.c_id="+C_ID;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            pnlShowStock.Controls.Clear(); int i = 1;string show = "";
            while(dr.Read())
            {
                string stock_id = dr["stock_id"].ToString();
                string ProductName = dr["ProductName"].ToString();
                string BuyQuantity = dr["BuyQuantity"].ToString();
                string BuyingPrice = dr["BuyingPrice"].ToString();
                string Amount = dr["Amount"].ToString();
                string Unit = dr["Unit"].ToString();
                show += string.Format(@"<tr>
                        <td>{0}</td>
<td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td>
                </tr>", i,stock_id,ProductName,Unit,BuyQuantity,BuyingPrice,Amount);
                i++;
            }
            con.Close();
            pnlShowStock.Controls.Add(new LiteralControl(show));
        }
        private void ShowStockList()
        {
            string C_ID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from StockList where c_id="+ C_ID;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string Show = "";int i = 1;
            pnlShowStockList.Controls.Clear();
            while(dr.Read())
            {
                string stock_id = dr["stock_id"].ToString();
                string Invoice = dr["Invoice"].ToString();
                string InputDate = dr["InputDate"].ToString();
                string TotalAmount = dr["TotalAmount"].ToString();
                string TotalStock = dr["TotalStock"].ToString();
                Show += string.Format(@"<tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                            <td>{2}</td>
                                            <td>{3}</td>
                                            <td>{4}</td>
                                            <td>{5}</td>
                                        </tr>",i,stock_id,Invoice, InputDate,TotalAmount,TotalStock);
                i++;
            }
            con.Close();
            pnlShowStockList.Controls.Add(new LiteralControl(Show));
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
                Response.Redirect("../CustomerSupplier/Supplier_Add?ed_id=" + Request.QueryString[""].ToString());
        }
    }
}