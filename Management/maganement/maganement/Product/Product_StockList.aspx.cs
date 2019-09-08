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
    public partial class Product_StockList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(!IsPostBack)
                {
                    Show();
                }
                if(Request.QueryString["de"]!=null)
                {
                    string StockID = Request.QueryString["de"].ToString();
                    if (Chk.int32CheckSecurity("select count(*) from StockList where stock_id='" + StockID + "' ", 1))
                    {
                        Chk.stringCheck("delete from StockList where stock_id='" + StockID + "' ");
                        Chk.stringCheck("delete from Stock where stock_id='" + StockID + "' ");
                        Response.Redirect("../Product/Product_StockList");
                    }
                    else
                    {
                        Response.Redirect("../Error?=Please check your url it not found any data.");
                    }
                }
                if (Request.QueryString["cng_id"]!=null && Request.QueryString["auth"]!=null)
                {
                    string StockID = Request.QueryString["cng_id"].ToString();
                    string Make = Request.QueryString["auth"].ToString();string Auth = "";
                    if (Make == "1")
                        Auth = "True";
                    else
                        Auth = "False";

                    if(Chk.int32CheckSecurity("select count(*) from StockList where stock_id='"+StockID+"' ", 1))
                    {
                        Chk.stringCheck("update StockList set Activity='"+Auth+ "' where stock_id='" + StockID + "' ");
                        Response.Redirect("../Product/Product_StockList");


                    }
                    else
                    {
                        Response.Redirect("../Error?=Please check your url it not found any data.");
                    }

                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }

        }

        private void Show()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @" SELECT stock_id
      ,InputDate
      ,TotalAmount
      ,TotalStock
      ,Activity
	  ,m_login.Name,
	   (select count(*) from [dbmanagement].[dbo].Stock where Stock.stock_id=StockList.stock_id)
	   as CountProduct 
  FROM [dbmanagement].[dbo].[StockList],[dbmanagement].[dbo].[m_login]
  where StockList.userid=m_login.userid
";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string data = "";
            pnlShow.Controls.Clear();
            while(dr.Read())
            {
                string stock_id = dr["stock_id"].ToString();
                string InputDate = dr["InputDate"].ToString();
                string TotalAmount = dr["TotalAmount"].ToString();
                string TotalStock = dr["TotalStock"].ToString();
                string Activity = dr["Activity"].ToString();
                string Name = dr["Name"].ToString();
                string CountProduct = dr["CountProduct"].ToString();
                string Author = "";string Auther_activity = "";string Author_css = "";int b = 0;
                string Sold_Css = "";string Return_product = "";
                if (Activity == "True")
                {
                    Author = "<i class='fa fa-dot-circle-o text-success'></i> Active <i class='caret'></i>";
                    Auther_activity = "Dective"; Author_css = "text-danger";
                    b = 0;
                    Return_product = "<li><a href='../Return/Purchase_Add?sid="+ stock_id + "' title='Return' ><i class='fa fa-undo m-r-5'></i> Return</a></li>";
                }
                else if(Activity == "False")
                {
                    Author = "<i class='fa fa-dot-circle-o text-danger'></i> Deactive <i class='caret'></i>";
                    Auther_activity = "Active"; Author_css = "text-success";
                    Return_product = "<li><a href='../Return/Purchase_Add?sid=" + stock_id + "' title='Return' ><i class='fa fa-undo m-r-5'></i> Return</a></li>";
                    b = 1;
                }
                else if(Activity=="Sold")
                {
                    Author = "<i class='fa fa-times text-danger'></i> Sold";
                    Auther_activity = ""; Author_css = "text-danger";
                    Sold_Css = "style='display:none;' ";
                    Return_product = "";
                }

                data += string.Format(@"<tr>
											<td>
												<strong>{0}</strong>
											</td>
											<td>{1}</td>
											<td>{2}</td>
											<td>{3}</td>
											<td>{4}</td>
											<td>{5}</td>
											<td class='text-center'>
												<div class='dropdown action-label'>
													<a class='btn btn-white btn-sm rounded dropdown-toggle' href='#' data-toggle='dropdown' aria-expanded='false'>
														{6}
													</a>
													<ul class='dropdown-menu pull-right' {10}>	
														<li><a href='../Product/Product_StockList?cng_id={0}&auth={9}'><i class='fa fa-dot-circle-o {8}'></i> {7}</a></li>
													</ul>
												</div>
											</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../invoice/?sid={0}' title='Edit' ><i class='fa fa-pencil m-r-5'></i> Invoice</a></li>
                                                        {11}
														<li><a href='../Product/Product_StockList?de={0}' title='Delete' ><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", stock_id,CountProduct,TotalAmount,TotalStock,InputDate,Name,Author,Auther_activity,Author_css,b,Sold_Css,Return_product);

            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(data));
        }
    }
}