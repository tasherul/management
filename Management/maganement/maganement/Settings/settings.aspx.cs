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


namespace maganement.Settings
{
    public partial class settings : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (!IsPostBack)
                {
                    txtCompanyAddress1.Text = chk.stringCheck("select ValueString from Settings where id=4");
                    txtCompanyAddress2.Text = chk.stringCheck("select ValueString from Settings where id=5");
                    txtCompanyName.Text = chk.stringCheck("select ValueString from Settings where id=3");
                    txtCompanyPhone.Text = chk.stringCheck("select ValueString from Settings where id=6");
                    txtInvoiceBarcodeFontSize.Text = chk.stringCheck("select ValueInt from Settings where id=9");
                    txtInvoiceBarcodeHeight.Text = chk.stringCheck("select ValueInt from Settings where id=11");
                    txtInvoiceBarcodeWidth.Text = chk.stringCheck("select ValueInt from Settings where id=10");
                    txtInvoiceID.Text = chk.stringCheck("select ValueInt from Settings where id=2");
                    txtStockID.Text = chk.stringCheck("select ValueInt from Settings where id=1");
                    txtTermsAndCondition.Text = chk.stringCheck("select ValueString from Settings where id=8");
                    ddlInvoiceAlign.SelectedValue = chk.stringCheck("select ValueString from Settings where id=12");
                    ddlInvoiceSize.SelectedValue = chk.stringCheck("select ValueString from Settings where id=13");
                    ddlRetuenPageSize.SelectedValue = chk.stringCheck("select ValueString from Settings where id=15");
                    ddlReturnPageAlign.SelectedValue = chk.stringCheck("select ValueString from Settings where id=14");
                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            chk.BoolSecurityCheck("update Settings set ValueString='"+ txtCompanyAddress1.Text + "' where id=4");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtCompanyAddress2.Text + "' where id=5");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtCompanyName.Text + "' where id=3");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtCompanyPhone.Text + "' where id=6");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtInvoiceBarcodeFontSize.Text + " where id=9");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtInvoiceBarcodeHeight.Text + " where id=11");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtInvoiceBarcodeWidth.Text + " where id=10");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtInvoiceID.Text + " where id=2");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtStockID.Text + " where id=1");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtTermsAndCondition.Text + "' where id=8");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlInvoiceAlign.SelectedValue.ToString() + "' where id=12");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlInvoiceSize.SelectedValue.ToString() + "' where id=13");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlRetuenPageSize.SelectedValue.ToString() + "' where id=15");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlReturnPageAlign.SelectedValue.ToString() + "' where id=14");

            if(ImageUpload.HasFile)
            {
                string Ext = Path.GetExtension(ImageUpload.FileName.ToLower());
                if(Ext==".jpg" || Ext==".png" || Ext==".jpeg" )
                {
                    string Name = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                    ImageUpload.SaveAs(Server.MapPath("~/image/" + Name + Ext));
                    chk.BoolSecurityCheck("update Settings set ValueString='" + Name+Ext + "' where id=7");
                }
                else
                {
                    lblResult.Text += "<div class='alert alert-danger'><span>Image File Need .jpg .png .jpeg</span></div>";
                }
            }

            lblResult.Text += "<div class='alert alert-success'><span>Save All Settings</span></div> ";


        }
    }
}