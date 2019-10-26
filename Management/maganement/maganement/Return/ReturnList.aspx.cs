using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.Return
{
    public partial class ReturnList : System.Web.UI.Page
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
                if(Request.QueryString["de_id"]!=null)
                {
                    string ID = Request.QueryString["de_id"].ToString();
                    if(_chk.BoolSecurityCheck("select count(*) from ReturnProduct where r_id="+ID))
                    {
                        _chk.BoolSecurityCheck("delete from ReturnProduct where r_id=" + ID);
                        Response.Redirect("../Return/Purchase_Add");
                    }
                    else
                    {
                        Response.Redirect("../Error?=Return ID Not Found");
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
            pnlShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from ReturnProduct";
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
                                            <td>{7}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../Invoice/Return?={8}' title='Invoice'><i class='fa fa-pencil m-r-5'></i> Invoice</a></li>
														<li><a href='../Return/Purchase_Add?de_id={8}' title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", num, ProductName, RetuenIteam, ReturnPrice, Amount, _chk.stringCheck("select Unit from ProductAdd where p_id=" + p_id.ToString()), c_id=="0"?"Null":_chk.stringCheck("select Name from Supplier where c_id="+c_id.ToString()), InputDate, r_id);
                num++;
            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(ShowD));
        }
    }
}