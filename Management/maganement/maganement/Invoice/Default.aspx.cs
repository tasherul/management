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

namespace management.Invoice
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        Barcodes bar = new Barcodes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {

                if (Request.QueryString[""]!=null)
                {
                string invoice = Request.QueryString[""].ToString();
                if (chk.int32CheckSecurity("select count(*) from SaleList where Invoice_no='" + invoice + "' ", 1))
                {
                    CompanyImage.ImageUrl = "../image/" + chk.stringCheck("select ValueString from Settings where id=7");
                    bar.BarcodeFontSize = chk.int32Check("select ValueInt from Settings where id=9");
                    bar.BarcodeWidth = chk.int32Check("select ValueInt from Settings where id=10");
                    bar.BarcodeHigth = chk.int32Check("select ValueInt from Settings where id=11");
                    lblTermsAndCondition.Text = chk.stringCheck("select ValueString from Settings where id=8");
                    BarcodeShow.ImageUrl = bar.BarcodeGenerator(invoice);
                    BarcodeShow.Height = bar.ImageHeigth;
                    BarcodeShow.Width = bar.ImageWidth;

                    lblInvoice.Text = invoice;

                    lblCompanyName.Text = chk.stringCheck("select ValueString from Settings where id=3");
                    lblCompanyAddress1.Text = chk.stringCheck("select ValueString from Settings where id=4");
                    lblCompanyAddress2.Text = chk.stringCheck("select ValueString from Settings where id=5");
                    lblCompanyPhone.Text = chk.stringCheck("select ValueString from Settings where id=6");
                    string st = " from SaleList where Invoice_no='" + invoice + "' ";
                    lblCustomarName.Text = chk.stringCheck("select CustomerName " + st);
                    lblCustomarAddress.Text = chk.stringCheck("select CustomerAddress " + st);
                    lblCustomarPhone.Text = chk.stringCheck("select CustomerMobile " + st);
                    lblorderID.Text = chk.stringCheck("select sale_id " + st);
                    lblDate.Text = chk.stringCheck("select SubmitDate " + st);

                    lblDiscount.Text = chk.stringCheck("select DiscountAmount " + st);
                    lblDue.Text = chk.stringCheck("select TotalDue " + st);
                    lblPaid.Text = chk.stringCheck("select Payment " + st);
                    lblPreviousDue.Text = chk.stringCheck("select PreviousDue " + st);
                    lblSubTotal.Text = chk.stringCheck("select SubTotal " + st);
                    double Payment = Convert.ToDouble(chk.int32Check("select Payment " + st));
                    double TotalDue = Convert.ToDouble(chk.int32Check("select TotalDue " + st));
                    lblTotal.Text = (Payment + TotalDue).ToString();
                    lblVat.Text = chk.stringCheck("select VatAmount " + st);
                    lblInWord.Text = chk.stringCheck("select InWord " + st);
                    lblMemo.Text = chk.stringCheck("select Memo " + st);
                    divAlign.Attributes.Add("class", "row d-flex " + chk.stringCheck("select ValueString from Settings where id=12"));
                    divSize.Attributes.Add("class", chk.stringCheck("select ValueString from Settings where id=13"));
                    SaleProductList(invoice);
                }
                else
                {
                    Response.Redirect("../Error?=Invoice Not Found try Again");
                }



                }
            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }

        }

        private void SaleProductList(string invoice)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"select * from SaleProductList where Invoice_no='"+ invoice + "'";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string Show = "";int i = 1;
            pnlShowStock.Controls.Clear();
            while(dr.Read())
            {
                string ProductName = dr["ProductName"].ToString();
                string Quantity = dr["Quantity"].ToString();
                string Unit = dr["Unit"].ToString();
                string SellingPrice = dr["SellingPrice"].ToString();
                string Amount = dr["Amount"].ToString();
                string p_id = dr["p_id"].ToString();
                Show += string.Format(@"<tr>
                                                                <td>{0}</td>
                                                                <td>{1}</td>
                                                                <td>{5}</td>
                                                                <td>{2}</td>
                                                                <td>{3}</td>
                                                                <td>{4}</td>
                                                            </tr>", i, ProductName, Quantity, SellingPrice, Amount, chk.stringCheck("select Description from ProductAdd where  p_id="+p_id));
                i++;

            }
            pnlShowStock.Controls.Add(new LiteralControl(Show));
            con.Close();
        }
    }
}