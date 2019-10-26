using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.CustomerSupplier
{
    public partial class ViewCustomer : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(Request.QueryString[""]!=null)
                {
                    string ID = Request.QueryString[""].ToString();
                    if(_Chk.int32Check("select count(*) from Customer where c_id="+ID)==1)
                    {
                        string st = " from Customer where c_id=" + ID;
                        lblName.Controls.Add(new LiteralControl(_Chk.stringCheck("select Name"+st)));
                        lblCustomerID.Controls.Add(new LiteralControl(ID));
                        lblDetails.Controls.Add(new LiteralControl(_Chk.stringCheck("select Details" + st)));
                        lblEmail.Controls.Add(new LiteralControl(_Chk.stringCheck("select Email" + st)));
                        lblGender.Controls.Add(new LiteralControl(_Chk.stringCheck("select Gender" + st)));
                        lblPhone.Controls.Add(new LiteralControl(_Chk.stringCheck("select Mobile" + st)));
                        lblAddress.Controls.Add(new LiteralControl(_Chk.stringCheck("select Address" + st)));
                        Show();

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

        private void Show()
        {
            string ID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @" SELECT * from SaleList where c_id="+ ID;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string data = "";
            pnlShow.Controls.Clear(); int i = 0;
            while (dr.Read())
            {
                string Invoice_no = dr["Invoice_no"].ToString();
                string Memo = dr["Memo"].ToString();
                string CustomerName = dr["CustomerName"].ToString();
                string CustomerMobile = dr["CustomerMobile"].ToString();
                string TotalProduct = dr["TotalProduct"].ToString();
                string TotalQuantity = dr["TotalQuantity"].ToString();
                string SubTotal = dr["SubTotal"].ToString();
                string Payment = dr["Payment"].ToString();
                string TotalDue = dr["TotalDue"].ToString();
                string SubmitDate = dr["SubmitDate"].ToString();
                string saleType = dr["saleType"].ToString();

                data += string.Format(@"<tr>
											<td>
												<strong>{0}</strong>
											</td>
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
														<li><a target='_blank' href='../invoice/?={0}' title='Edit' ><i class='fa fa-pencil m-r-5'></i> Invoice</a></li>
														<li><a  href='../Product/SaleList?de={0}' title='Delete' ><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", Invoice_no, Memo, TotalProduct, TotalQuantity, SubTotal, Payment, TotalDue, SubmitDate, saleType);

            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(data));
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            Response.Redirect("../CustomerSupplier/Customer_Add?ed_id=" + Request.QueryString[""].ToString());
        }
    }
}