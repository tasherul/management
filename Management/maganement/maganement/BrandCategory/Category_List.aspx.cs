using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement.BrandCategory
{
    public partial class Category_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private void ShowData()
        {
            DropDownList ddlWireHouse = Master.FindControl("WireHouse") as DropDownList;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString))
            {
                string WH_ID = ddlWireHouse.SelectedValue.ToString();
                string Show = "";
                pnlShow.Controls.Clear();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Category where wirehouse_id='" + WH_ID + "' ";
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    string C_id = dr["c_id"].ToString();
                    string CategoryName = dr["CategoryName"].ToString();

                    Show += string.Format(@"<tr>
											<td>{0}</td>
											<td>{1}</td>
											<td class='text-right'>
												<div class='dropdown'>
													<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
													<ul class='dropdown-menu pull-right'>
														<li><a href='../BrandCategory/Categoty_Add?c_id={0}'  title='Edit'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
														<li><a href='../BrandCategory/Categoty_Add?dc_id={0}'  title='Delete'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
													</ul>
												</div>
											</td>
										</tr>", C_id,CategoryName);

                }
                con.Close();
                pnlShow.Controls.Add(new LiteralControl(Show));
            }
        }


    }
}