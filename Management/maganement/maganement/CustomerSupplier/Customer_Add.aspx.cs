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
    public partial class Customer_Add : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                btnUpdate.Visible = false;
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        AntiInjection _Anti = new AntiInjection();
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if(txtName.Text!="" && txtMobileNumber.Text!="")
            {
                string Name = txtName.Text;
                string Mobile = txtMobileNumber.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                string Details = txtDetails.Text;
                _Anti.FullName = true;_Anti.Email = true;_Anti.Address = true;
                if(_Anti.StringData(Name))
                { }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Name and Mobile number Requid.</span></div> ";
            }
        }
    }
}