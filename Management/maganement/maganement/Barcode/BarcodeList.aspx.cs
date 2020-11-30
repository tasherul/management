using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.Barcode
{
    public partial class BarcodeList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbm"].ConnectionString);
        Verification _VR = new Verification();
        Check chk = new Check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["m_UserID"] != null && _VR.Check(Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath), Session["m_UserID"].ToString()))
            {
                if(!IsPostBack)
                {
                    showProdut();
                }

            }
            else
            {
                if (Session["m_UserID"] != null)
                    Response.Redirect("~/AuthorizationFailed");
                else
                    Response.Redirect("~/Login?=" + Request.Url.AbsolutePath);
            }

        }
        private void showProdut()
        {
            ddlProduct.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select Name,p_id from ProductAdd";
            con.Open();
            ddlProduct.Items.Add(new ListItem("ALL", ""));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem li = new ListItem();
                li.Text = dr["Name"].ToString();
                li.Value = dr["p_id"].ToString();
                ddlProduct.Items.Add(li);
            }
            con.Close();

        }
    }
}