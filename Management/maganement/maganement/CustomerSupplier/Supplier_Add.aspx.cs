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
    public partial class Supplier_Add : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                btnUpdate.Visible = false;
                if (Request.QueryString["ed_id"] != null)
                {
                    btnCreate.Visible = false;
                    btnUpdate.Visible = true;
                    string ID = Request.QueryString["ed_id"].ToString();
                    string st = " from Supplier where c_id=" + ID;
                    if (!IsPostBack)
                    {
                        txtAddress.Text = _Chk.stringCheck("select Address " + st);
                        txtDetails.Text = _Chk.stringCheck("select Details " + st);
                        txtEmail.Text = _Chk.stringCheck("select Email " + st);
                        txtMobileNumber.Text = _Chk.stringCheck("select Mobile " + st);
                        txtName.Text = _Chk.stringCheck("select Name " + st);
                        ddlGender.SelectedValue = _Chk.stringCheck("select Gender " + st);
                    }
                }
                if (Request.QueryString["de_id"] != null)
                {
                    pnlDelete.Visible = false;
                    btnCreate.Visible = false;
                    btnUpdate.Visible = false;
                    if (_Chk.BoolSecurityCheck("delete from Supplier where c_id=" + Request.QueryString["de_id"].ToString()))
                    {
                        lblResult.Text = "<div class='alert alert-success'><span>Supplier Delete.</span></div> ";
                    }
                    else
                    {
                        lblResult.Text = "<div class='alert alert-danger'><span>" + _Chk.BoolSecurityErrorMessege + "</span></div> ";
                    }
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }
        AntiInjection _Anti = new AntiInjection();
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobileNumber.Text != "")
            {
                string Name = txtName.Text;
                string Mobile = txtMobileNumber.Text;
                string Address = txtAddress.Text;
                string Email = txtEmail.Text;
                string Details = txtDetails.Text;
                if (_Chk.BoolSecurityCheck(string.Format(@"insert into Supplier (Name,Email,Mobile,Gender,Address,Details) Values('{0}','{1}','{2}','{3}','{4}','{5}' )", Name, Email, Mobile, ddlGender.SelectedValue.ToString(), Address, Details)))
                {
                    lblResult.Text = "<div class='alert alert-success'><span> Successfully Supplier Added.</span></div> ";
                    txtAddress.Text = "";
                    txtDetails.Text = "";
                    txtEmail.Text = "";
                    txtMobileNumber.Text = "";
                    txtName.Text = "";
                    ddlGender.SelectedValue = "Null";
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>" + _Chk.BoolSecurityErrorMessege + "</span></div> ";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Name and Mobile number Requid.</span></div> ";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtMobileNumber.Text != "" & Request.QueryString["ed_id"] != null)
            {
                if (_Chk.BoolSecurityCheck(string.Format("update Supplier set Name='{0}',Email='{1}',Mobile='{2}',Gender='{3}',Address='{4}',Details='{5}' where c_id={6}",
                    txtName.Text, txtEmail.Text, txtMobileNumber.Text, ddlGender.SelectedValue.ToString(), txtAddress.Text, txtDetails.Text, Request.QueryString["ed_id"].ToString())))
                {
                    lblResult.Text = "<div class='alert alert-success'><span> Successfully Supplier Update.</span></div> ";
                    txtAddress.Text = "";
                    txtDetails.Text = "";
                    txtEmail.Text = "";
                    txtMobileNumber.Text = "";
                    txtName.Text = "";
                    ddlGender.SelectedValue = "Null";
                }
                else
                {
                    lblResult.Text = "<div class='alert alert-danger'><span>" + _Chk.BoolSecurityErrorMessege + "</span></div> ";
                }
            }
            else
            {
                lblResult.Text = "<div class='alert alert-danger'><span>Name and Mobile number Requid.</span></div> ";
            }
        }
    }
}