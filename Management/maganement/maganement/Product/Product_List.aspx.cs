using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace maganement.Product
{
    public partial class Product_List : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check _chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                {
                    Show();
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        private void Show()
        {
            pnlShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ProductAdd";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int num = 1;string ShowD = "";
            while (dr.Read())
            {
                string Name = dr["Name"].ToString();
                string BuingPrice = dr["BuingPrice"].ToString();
                string SellingPrice = dr["SellingPrice"].ToString();
                string Unit = dr["Unit"].ToString();
                string Brand = dr["Brand"].ToString();
                string Date = dr["InputDate"].ToString();
                string ID = dr["p_id"].ToString();
                ShowD += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td>{2}</td>
											<td>{3}</td>
											<td>{4}</td>
											<td>{5}</td>
                                            <td>{6}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../Product/Product_Add?ed_id={7}' title='Edit'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../Product/Product_Add?de_id={7}' title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", num,Name,BuingPrice,SellingPrice,Unit,Brand,Date,ID);
                num++;
            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(ShowD));


        }


    }
}