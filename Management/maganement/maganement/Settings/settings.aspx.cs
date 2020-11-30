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


namespace management.Settings
{
    public partial class settings : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        Barcodes barCode = new Barcodes();
        management.settings set = new management.settings();
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

                    txtBarcodeNumber.Text= chk.stringCheck("select ValueInt from Settings where id=16");
                    txtBarcodeWidth.Text = chk.stringCheck("select ValueInt from Settings where id=17");
                    txtBarcodeHigth.Text = chk.stringCheck("select ValueInt from Settings where id=18");
                    txtBarcodeFontSize.Text = chk.stringCheck("select ValueInt from Settings where id=19");
                    txtBarcodePointX.Text = chk.stringCheck("select ValueString from Settings where id=20");
                    txtBarcodePointY.Text = chk.stringCheck("select ValueString from Settings where id=21");
                    txtBarCodeFontName.Text = chk.stringCheck("select ValueString from Settings where id=23");
                    ddlBarcodePageLine.SelectedValue = chk.stringCheck("select ValueString from Settings where id=26");
                    txtBarcodeImageWidth.Text = chk.stringCheck("select ValueString from Settings where id=27");
                    chkBarcode_CompanyTag.Checked = set.Get_BoolValue_Settings(24);
                    chkBarcode_PriceTag.Checked = set.Get_BoolValue_Settings(25);
                    txtBarcode_CompanyNameSize.Text = set.Get_InValue_Settings(28).ToString();
                    txtBarcode_CompanyPointX.Text = set.Get_StringValue_Settings(29);
                    txtBarcode_CompanyPointY.Text = set.Get_StringValue_Settings(30);
                    txtBarcode_CompanyFontName.Text = set.Get_StringValue_Settings(31);
                    txtBarcode_CompanyFontSize.Text = set.Get_InValue_Settings(32).ToString();
                    txtBarcode_PriceTagSize.Text = set.Get_InValue_Settings(34).ToString();
                    txtBarcode_PricePointX.Text = set.Get_StringValue_Settings(35);
                    txtBarcode_PriceFontName.Text = set.Get_StringValue_Settings(36);
                    txtBarcode_PriceFontSize.Text = set.Get_InValue_Settings(37).ToString();
                    txtBarcode_CompanyName.Text = set.Get_StringValue_Settings(39);
                    txtBarcode_PriceTag.Text = set.Get_StringValue_Settings(40);

                    chkSalePrice.Checked = set.Get_BoolValue_Settings(41);
                    chkBarcodeQuality.Checked = set.Get_BoolValue_Settings(42);
                    chkAlertBuyPrice.Checked = set.Get_BoolValue_Settings(43);

                    ddlColor.Items.Clear();
                    ddlBarcode_CompanyColor.Items.Clear();
                    ddlBarcode_PriceColor.Items.Clear();
                    foreach (string s in barCode.BarcodeAllColor)
                    {
                        ddlColor.Items.Add(new ListItem(s,s));
                        ddlBarcode_CompanyColor.Items.Add(new ListItem(s, s));
                        ddlBarcode_PriceColor.Items.Add(new ListItem(s, s));
                    }
                    ddlColor.SelectedValue= chk.stringCheck("select ValueString from Settings where id=22");
                    ddlBarcode_CompanyColor.SelectedValue = chk.stringCheck("select ValueString from Settings where id=33");
                    ddlBarcode_PriceColor.SelectedValue = chk.stringCheck("select ValueString from Settings where id=38");
                }
            }
            else
            {
                if (Session["m_UserID"] != null)
                    Response.Redirect("~/AuthorizationFailed");
                else
                    Response.Redirect("~/Login?=/Settings/Settings");
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

            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcodeNumber.Text + " where id=16");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcodeWidth.Text + " where id=17");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcodeHigth.Text + " where id=18");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcodeFontSize.Text + " where id=19");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcodePointX.Text + "' where id=20");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcodePointY.Text  + "' where id=21");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarCodeFontName.Text  + "' where id=23");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlColor.SelectedItem.ToString() + "' where id=22");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlBarcodePageLine.SelectedValue.ToString() + "' where id=26");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcodeImageWidth.Text + "' where id=27");


            chk.BoolSecurityCheck("update Settings set Value_Bool='" + chkBarcode_CompanyTag.Checked + "' where id=25");
            chk.BoolSecurityCheck("update Settings set Value_Bool='" + chkBarcode_PriceTag.Checked + "' where id=24");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcode_CompanyNameSize.Text + " where id=28");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_CompanyPointX.Text + "' where id=29");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_CompanyPointY.Text + "' where id=30");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_CompanyFontName.Text + "' where id=31");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcode_CompanyFontSize.Text + " where id=32");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlBarcode_CompanyColor.SelectedValue.ToString() + "' where id=33");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcode_PriceTagSize.Text + " where id=34");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_PricePointX.Text + "' where id=35");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_PriceFontName.Text + "' where id=36");
            chk.BoolSecurityCheck("update Settings set ValueInt=" + txtBarcode_PriceFontSize.Text + " where id=37");
            chk.BoolSecurityCheck("update Settings set ValueString='" + ddlBarcode_PriceColor.SelectedValue.ToString() + "' where id=38");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_CompanyName.Text + "' where id=39");
            chk.BoolSecurityCheck("update Settings set ValueString='" + txtBarcode_PriceTag.Text + "' where id=40");
            chk.BoolSecurityCheck("update Settings set Value_Bool='" + chkSalePrice.Checked + "' where id=41");
            chk.BoolSecurityCheck("update Settings set Value_Bool='" + chkBarcodeQuality.Checked + "' where id=42");
            chk.BoolSecurityCheck("update Settings set Value_Bool='" + chkAlertBuyPrice.Checked + "' where id=43");

            if (ImageUpload.HasFile)
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