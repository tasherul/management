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
    public partial class ViewSupplier : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if (Request.QueryString[""] != null)
                {
                    string ID = Request.QueryString[""].ToString();
                    if (_Chk.int32Check("select count(*) from Supplier where c_id=" + ID) == 1)
                    {
                        string st = " from Supplier where c_id=" + ID;
                        lblName.Controls.Add(new LiteralControl(_Chk.stringCheck("select Name" + st)));
                        lblCustomerID.Controls.Add(new LiteralControl(ID));
                        lblDetails.Controls.Add(new LiteralControl(_Chk.stringCheck("select Details" + st)));
                        lblEmail.Controls.Add(new LiteralControl(_Chk.stringCheck("select Email" + st)));
                        lblGender.Controls.Add(new LiteralControl(_Chk.stringCheck("select Gender" + st)));
                        lblPhone.Controls.Add(new LiteralControl(_Chk.stringCheck("select Mobile" + st)));
                        lblAddress.Controls.Add(new LiteralControl(_Chk.stringCheck("select Address" + st)));

                        ShowStockList();

                    }
                    else
                    {
                        Response.Redirect("Error?=Customer Not Found.");
                    }
                }


            }
            else
            {
                Response.Redirect("~/AuthorizationFailed");
            }


        }
        private void ShowStock()
        {

        }
        private void ShowStockList()
        {
            string C_ID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from StockList where c_id="+ C_ID;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string Show = "";int i = 1;
            pnlShowStockList.Controls.Clear();
            while(dr.Read())
            {
                string stock_id = dr["stock_id"].ToString();
                string Invoice = dr["Invoice"].ToString();
                string InputDate = dr["InputDate"].ToString();
                string TotalAmount = dr["TotalAmount"].ToString();
                string TotalStock = dr["TotalStock"].ToString();
                Show += string.Format(@"<tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                            <td>{2}</td>
                                            <td>{3}</td>
                                            <td>{4}</td>
                                            <td>{5}</td>
                                        </tr>",i,stock_id,Invoice, InputDate,TotalAmount,TotalStock);
                i++;
            }
            con.Close();
            pnlShowStockList.Controls.Add(new LiteralControl(Show));
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
                Response.Redirect("../CustomerSupplier/Supplier_Add?ed_id=" + Request.QueryString[""].ToString());
        }
    }
}