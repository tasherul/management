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

namespace maganement.Invoice
{
    public partial class Return : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        Barcodes bar = new Barcodes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
            {
                string invoice = Request.QueryString[""].ToString();
                if (chk.int32CheckSecurity("select count(*) from ReturnProduct where r_id=" + invoice, 1))
                {
                    CompanyImage.ImageUrl = "../image/" + chk.stringCheck("select ValueString from Settings where id=7");
                    //bar.BarcodeFontSize = chk.int32Check("select ValueInt from Settings where id=9");
                    //bar.BarcodeWidth = chk.int32Check("select ValueInt from Settings where id=10");
                    //bar.BarcodeHigth = chk.int32Check("select ValueInt from Settings where id=11");
                    //lblTermsAndCondition.Text = chk.stringCheck("select ValueString from Settings where id=8");
                    //BarcodeShow.ImageUrl = bar.BarcodeGenerator(invoice);
                    //BarcodeShow.Height = bar.ImageHeigth;
                    //BarcodeShow.Width = bar.ImageWidth;

                    lblInvoice.Text = invoice;

                    lblCompanyName.Text = chk.stringCheck("select ValueString from Settings where id=3");
                    lblCompanyAddress1.Text = chk.stringCheck("select ValueString from Settings where id=4");
                    lblCompanyAddress2.Text = chk.stringCheck("select ValueString from Settings where id=5");
                    lblCompanyPhone.Text = chk.stringCheck("select ValueString from Settings where id=6");

                    string st = " from ReturnProduct where r_id=" + invoice ;
                    string SupploerID = chk.stringCheck("select c_id " + st);
                    if (SupploerID != "0")
                    {
                        var supplier = " from Supplier where c_id=" + SupploerID;

                        lblCustomarName.Text = chk.stringCheck("select Name " + supplier);
                        lblCustomarAddress.Text = chk.stringCheck("select Address " + supplier);
                        lblCustomarPhone.Text = chk.stringCheck("select Mobile " + supplier);
                    }
                    lblDate.Text = chk.stringCheck("select InputDate " + st);
                    lblTotal.Text = chk.stringCheck("select Amount " + st);
                    lblTotal.Text = chk.stringCheck("select Amount " + st);

                    lblProductName.Text = chk.stringCheck("select ProductName " + st);
                    lblDiscription.Text = chk.stringCheck("select Remark " + st);
                    lblReturnPrice.Text = chk.stringCheck("select ReturnPrice " + st);
                    lblQuantity.Text = chk.stringCheck("select RetuenIteam " + st);
                    lblTotalCost.Text = chk.stringCheck("select Amount " + st);


                    divAlign.Attributes.Add("class", "row d-flex " + chk.stringCheck("select ValueString from Settings where id=14"));
                    divSize.Attributes.Add("class", chk.stringCheck("select ValueString from Settings where id=15"));

                }
                else
                {
                    Response.Redirect("../Error?=Invoice Not Found try Again");
                }
            }
        }


    }
}