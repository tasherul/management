using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.Expanse
{
    public partial class ExpanseCategory : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {



            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        Check chk = new Check();
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (chk.BoolSecurityCheck("insert into ExpanseCategory (CategoryName) values('" + txtCategoryName.Text + "')"))
            {
                lblResult.Text = "<div class='alert alert-success'><span>Categoty Add Sucessful</span></div> ";
                txtCategoryName.Text = "";
                GridView1.DataBind();
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>" + chk.BoolSecurityErrorMessege + "</span></div> ";
            }
        }



    }
}