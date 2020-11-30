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
    public partial class Customer_List : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {

                Show_Data();

            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        private void Show_Data()
        {
            pnlShow.Controls.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Customer";
            con.Open();
            string Show = "";
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                string ID = dr["c_id"].ToString();
                string Name = dr["Name"].ToString();
                string Mobile = dr["Mobile"].ToString();
                string FirstLetter = Name.Substring(0, 1).ToUpper();
                Show += string.Format(@"<div class='col-md-4 col-sm-4 col-xs-6 col-lg-3'>
							<div class='profile-widget'>
								<div class='profile-img'>
									<a href='../CustomerSupplier/ViewCustomer?={0}' class='avatar'>{3}</a>
								</div>
								<div class='dropdown profile-action'>
									<a href='#' class='action-icon dropdown-toggle' data-toggle='dropdown' aria-expanded='false'><i class='fa fa-ellipsis-v'></i></a>
									<ul class='dropdown-menu pull-right'>
										<li><a href='../CustomerSupplier/Customer_Add?ed_id={0}'><i class='fa fa-pencil m-r-5'></i> Edit</a></li>
										<li><a href='../CustomerSupplier/Customer_Add?de_id={0}'><i class='fa fa-trash-o m-r-5'></i> Delete</a></li>
									</ul>
								</div>
								<h4 class='user-name m-t-10 m-b-0 text-ellipsis'><a href='../CustomerSupplier/ViewCustomer?={0}'>{1}</a></h4>
								<h5 class='user-name m-t-10 m-b-0 text-ellipsis'><a href='../CustomerSupplier/ViewCustomer?={0}'>{2}</a></h5>
								<div class='small text-muted'>Customer</div>
								<a href='../CustomerSupplier/ViewCustomer?={0}' class='btn btn-default btn-sm m-t-10'>View Profile</a>
							</div> 
						</div>", ID,Name,Mobile,FirstLetter);
            }
            con.Close();
            pnlShow.Controls.Add(new LiteralControl(Show));
        }


    }
}