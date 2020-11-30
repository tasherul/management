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
    public partial class Stock : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        Barcodes bar = new Barcodes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (Request.QueryString[""] != null)
                {
                    string invoice = Request.QueryString[""].ToString();
                    if (chk.int32CheckSecurity("select count(*) from StockList where stock_id=" + invoice , 1))
                    {
                        CompanyImage.ImageUrl = "../image/" + chk.stringCheck("select ValueString from Settings where id=7");
                        bar.BarcodeFontSize = chk.int32Check("select ValueInt from Settings where id=9");
                        bar.BarcodeWidth = chk.int32Check("select ValueInt from Settings where id=10");
                        bar.BarcodeHigth = chk.int32Check("select ValueInt from Settings where id=11");
                        //lblTermsAndCondition.Text = chk.stringCheck("select ValueString from Settings where id=8");
                        BarcodeShow.ImageUrl = bar.BarcodeGenerator(invoice);
                        BarcodeShow.Height = bar.ImageHeigth;
                        BarcodeShow.Width = bar.ImageWidth;

                        lblInvoice.Text = invoice;

                        lblCompanyName.Text = chk.stringCheck("select ValueString from Settings where id=3");
                        lblCompanyAddress1.Text = chk.stringCheck("select ValueString from Settings where id=4");
                        lblCompanyAddress2.Text = chk.stringCheck("select ValueString from Settings where id=5");
                        lblCompanyPhone.Text = chk.stringCheck("select ValueString from Settings where id=6");

                    


                        string st = " from StockList where stock_id='" + invoice+"'";
                        string SupplerID = chk.stringCheck("select c_id "+st);


                        lblCustomarName.Text = chk.stringCheck("select Name from Supplier where c_id="+ SupplerID);
                        lblCustomarAddress.Text = chk.stringCheck("select Address from Supplier where c_id=" + SupplerID);
                        lblCustomarPhone.Text = chk.stringCheck("select Mobile from Supplier where c_id=" + SupplerID);

                        //lblorderID.Text = chk.stringCheck("select sale_id " + st);
                        lblDate.Text = chk.stringCheck("select InputDate " + st);

                        //lblDiscount.Text = chk.stringCheck("select DiscountAmount " + st);
                        //lblDue.Text = chk.stringCheck("select TotalDue " + st);
                        lblPaid.Text = chk.stringCheck("select TotalAmount " + st);
                        //lblPreviousDue.Text = chk.stringCheck("select PreviousDue " + st);
                        lblSubTotal.Text = chk.stringCheck("select TotalStock " + st);
                        //lblVat.Text = chk.stringCheck("select VatAmount " + st);
                        //lblInWord.Text = chk.stringCheck("select InWord " + st);
                        //lblMemo.Text = chk.stringCheck("select Memo " + st);
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
            cmd.CommandText = @"select * from Stock where stock_id='" + invoice + "'";
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string Show = ""; int i = 1;
            pnlShowStock.Controls.Clear();
            while (dr.Read())
            {
                string stock_id = dr["stock_id"].ToString();
                string ProductName = dr["ProductName"].ToString();
                string BuyQuantity = dr["BuyQuantity"].ToString();
                string BuyingPrice = dr["BuyingPrice"].ToString();
                string Amount = dr["Amount"].ToString();
                string Unit = dr["Unit"].ToString();
                string p_id = dr["p_id"].ToString();
                Show += string.Format(@"<tr>
                                                                <td>{0}</td>
                                                                <td>{1}</td>
                                                                <td>{2}</td>
                                                                <td>{3}</td>
                                                                <td>{4}</td>
                                                                <td>{5}</td>
                                                            </tr>", i, ProductName,chk.stringCheck("select Description from ProductAdd where p_id="+ p_id), BuyQuantity, BuyingPrice, Amount);
                i++;
            }
            con.Close();
            pnlShowStock.Controls.Add(new LiteralControl(Show));
            
        }
    }
}