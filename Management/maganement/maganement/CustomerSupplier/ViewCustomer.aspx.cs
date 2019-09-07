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
    public partial class ViewCustomer : System.Web.UI.Page
    {
        Verification _VR = new Verification();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Check _Chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(Request.QueryString[""]!=null)
                {
                    string ID = Request.QueryString[""].ToString();
                    if(_Chk.int32Check("select count(*) from Customer where c_id="+ID)==1)
                    {
                        string st = " from Customer where c_id=" + ID;
                        lblName.Controls.Add(new LiteralControl(_Chk.stringCheck("select Name"+st)));
                        lblCustomerID.Controls.Add(new LiteralControl(ID));
                        lblDetails.Controls.Add(new LiteralControl(_Chk.stringCheck("select Details" + st)));
                        lblEmail.Controls.Add(new LiteralControl(_Chk.stringCheck("select Email" + st)));
                        lblGender.Controls.Add(new LiteralControl(_Chk.stringCheck("select Gender" + st)));
                        lblPhone.Controls.Add(new LiteralControl(_Chk.stringCheck("select Mobile" + st)));
                        lblAddress.Controls.Add(new LiteralControl(_Chk.stringCheck("select Address" + st)));


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

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            Response.Redirect("../CustomerSupplier/Customer_Add?ed_id=" + Request.QueryString[""].ToString());
        }
    }
}